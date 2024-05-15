using JsonManipulator.Models;
using JsonManipulator.OpenAPIs;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace JsonManipulator
{
    public partial class frmServicesApiModelChat : Form
    {
        private WaveIn waveIn;
        private WaveFileWriter writer;
        private bool isListening = false;
        private bool isRecording = false;
        private int silenceCounter = 0;
        private string currentRecordingFilePath = string.Empty;

        public string ReturnValue { get; set; }

        public frmServicesApiModelChat()
        {
            InitializeComponent();
            InitializeAudioRecording();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                return;
            }

            btnAccept.Enabled = false;

            string queryText = textBox1.Text;

            textBox1.Text = ""; 

            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": User : " + queryText);

            string projectCodeVal = Form1._model.root.ProjectCode;
             
            Console.WriteLine("waveIn.StopRecording");
            isListening = false;
            waveIn.StopRecording();

            lblStatus.Text = "Sending...";

            Guid projectCode = Guid.Parse(projectCodeVal);
            ChatResponse response = await OpenAPIs.ApiManager.AddModelChatQueryAsync(queryText, chkVoiceOutput.Checked, projectCode);

            lblStatus.Text = "";

            if (response.ResponseAudioUrl != null &&
                response.ResponseAudioUrl.Trim().Length > 0)
            {
                //verify url exists
                bool urlExists = await UrlExistsAsync(response.ResponseAudioUrl);

                if(urlExists)
                {
                    string tempFile = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString() + ".mp3";
                      
                    //download file
                    await DownloadUrl(response.ResponseAudioUrl, tempFile);

                    //play file
                    await PlayMP3File(tempFile);
                }
            }

            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": AI   : " + response.ResponseText);

            btnAccept.Enabled = true;


            Console.WriteLine("waveIn.StartRecording");
            waveIn.StartRecording();
            isListening = true;

            textBox1.Focus();
        }

        static async Task<bool> UrlExistsAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a HEAD request
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check if the response indicates success (status code 200-299)
                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException)
                {
                    // Handle exception if the request fails, e.g., due to network errors
                    return false;
                }
            }
        }


        public async Task<bool> DownloadUrl(string url, string destinationFilePath)
        {
            Console.WriteLine("DownloadUrl start");
            lblStatus.Text = "Downloading...";


            bool result = false;

            Console.WriteLine("DownloadUrl:  " + url);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Send a GET request to the robots.txt URL
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the request was successful (status code 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content into a byte array
                        byte[] content = await response.Content.ReadAsByteArrayAsync();

                        // Write the content to a file
                        File.WriteAllBytes(destinationFilePath, content);

                        result = true;
                    }
                    else
                    {
                        Console.WriteLine("url does not exist.");
                    }
                }
            }
            catch (Exception e)
            {
                // Handle any errors that might occur
                Console.WriteLine($"An error occurred on DownloadUrl: {e.Message}");
            }

            lblStatus.Text = "";

            Console.WriteLine("DownloadUrl end");
            return result;
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            Console.WriteLine("OnPlaybackStopped");
            lblStatus.Text = "";
        }

        private async Task PlayMP3File(string mp3FilePath)
        {

            Console.WriteLine("PlayMP3File start");

            lblStatus.Text = "Playing...";

            //using (var audioFile = new Mp3FileReader(mp3FilePath))
            //{
            //    WaveChannel32 volumeStream = new WaveChannel32(audioFile);

            //    WaveOutEvent player = new WaveOutEvent();

            //    player.Init(volumeStream);

            //    player.Play();
            //}

            WaveStream mainOutputStream = new Mp3FileReader(mp3FilePath);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);

            WaveOutEvent player = new WaveOutEvent();
            player.PlaybackStopped += OnPlaybackStopped;

            // WaveOut player = new WaveOut();

            player.Init(volumeStream);

            player.Play();

            Console.WriteLine("PlayMP3File end");

        }
        private async Task PlayWAVFile(string filePath)
        {
            using (SoundPlayer player = new SoundPlayer(filePath))
            {
                player.Load(); // Loads the .wav file
                //player.PlaySync(); // Plays the .wav file and blocks the calling thread until the file is finished
                player.Play(); // Use this instead if you want to play the sound asynchronously
            }
        }

        private async void FrmAddColumn_Load(object sender, EventArgs e)
        {

            string projectCodeVal = Form1._model.root.ProjectCode;

            Guid projectCode = Guid.Parse(projectCodeVal);
            ChatResponse response = await OpenAPIs.ApiManager.AddModelChatQueryAsync("new thread", false, projectCode);


            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": AI   : " + response.ResponseText);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the ding sound when pressing enter
                e.SuppressKeyPress = true;
                // Trigger the button click
                btnAccept.PerformClick();
            }
        }

        private void AppendTextAndScroll(string text)
        {
            if (text.Trim().Length == 0)
                return;
            Console.WriteLine("AppendTextAndScroll start");

            // Suspend layout to prevent flickering
            richTextBox1.SuspendLayout();

            // Save the current selection start and length
            int selStart = richTextBox1.SelectionStart;
            int selLength = richTextBox1.SelectionLength;

            // Set the selection to the end of the existing text
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            // Insert the text at the current selection, which is the end
            richTextBox1.SelectedText = Environment.NewLine + Environment.NewLine + text;

            // Scroll to the caret position, which is at the end after appending
            richTextBox1.ScrollToCaret();

            // Restore the previous selection
            richTextBox1.SelectionStart = selStart;
            richTextBox1.SelectionLength = selLength;

            // Resume layout to update the UI
            richTextBox1.ResumeLayout();
            Console.WriteLine("AppendTextAndScroll end");
        }


        //start voice recording\detection
        
        private void InitializeAudioRecording()
        {
            Console.WriteLine("InitializeAudioRecording start");
            waveIn = new WaveIn();
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
            waveIn.WaveFormat = new WaveFormat(44100, 1); // CD quality audio in mono 
            Console.WriteLine("waveIn.StartRecording");
            waveIn.StartRecording();
            isListening = true;
            Console.WriteLine("InitializeAudioRecording end");
        }

        private async void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            
            float volumeThreshold = 0.1f; // Set this to an appropriate level after testing
            int bufferMilliseconds = 2000; // Time in milliseconds to consider as silence before stopping recording
            bool signalDetected = false;

            // Simple energy calculation
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                if (Math.Abs(sample32) > volumeThreshold)
                {
                    lblStatus.Text = "Listening...";
                    signalDetected = true;
                    break;
                }
            }

            if (signalDetected)
            {
                if (!isRecording && chkVoiceInput.Checked)
                {
                    Console.WriteLine("starting recording");
                    string uniqueFileName = $"RecordedAudio_{DateTime.Now:yyyyMMddHHmmss}.wav";
                    currentRecordingFilePath = Path.Combine(System.IO.Path.GetTempPath(), uniqueFileName);
                    writer = new WaveFileWriter(currentRecordingFilePath, waveIn.WaveFormat);
                    Console.WriteLine("new writer created");
                    isRecording = true;
                }
                silenceCounter = 0;
            }
            else
            {
                if (isRecording)
                {
                    if (++silenceCounter > (int)(bufferMilliseconds / waveIn.BufferMilliseconds))
                    {
                        isRecording = false;

                        Console.WriteLine("waveIn.StopRecording");
                        isListening = false;
                        waveIn.StopRecording();

                        Console.WriteLine("writer.Close");
                        writer.Close();

                        btnAccept.Enabled = false;

                        string queryText = textBox1.Text;

                        textBox1.Text = "";

                        string projectCodeVal = Form1._model.root.ProjectCode;

                        DateTime requestDateTime = DateTime.Now;

                        lblStatus.Text = "Sending...";

                        Guid projectCode = Guid.Parse(projectCodeVal);
                        ChatResponse response = await OpenAPIs.ApiManager.AddModelChatQueryAsync("", chkVoiceOutput.Checked, projectCode, currentRecordingFilePath);

                        lblStatus.Text = "";

                        if (response.ResponseAudioUrl != null &&
                            response.ResponseAudioUrl.Trim().Length > 0)
                        {
                            //verify url exists
                            bool urlExists = await UrlExistsAsync(response.ResponseAudioUrl);

                            if (urlExists)
                            {
                                string tempFile = System.IO.Path.GetTempPath().TrimEnd(@"\".ToCharArray()) + @"\" + Guid.NewGuid().ToString() + ".mp3";

                                //download file
                                await DownloadUrl(response.ResponseAudioUrl, tempFile);

                                //play file
                                await PlayMP3File(tempFile);
                            }
                        }

                        AppendTextAndScroll(requestDateTime.ToLongTimeString() + ": User : " + response.QueryText);

                        AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": AI   : " + response.ResponseText);

                        btnAccept.Enabled = true;

                        Console.WriteLine("waveIn.StartRecording");
                        waveIn.StartRecording();
                        isListening = true;
                    }
                }
            }

            // Write buffer to file if recording
            if (isRecording && writer != null)
            {
                lblStatus.Text = "Recording...";
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            } 
        }

        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("OnRecordingStopped start");
            if (!isListening)
            {
                if (writer != null)
                {
                    Console.WriteLine("writer.Dispose");
                    writer.Dispose();
                    writer = null;
                    isRecording = false;
                    silenceCounter = 0;
                }

                if (e.Exception != null)
                {
                    Console.WriteLine("OnRecordingStopped error");
                    Console.WriteLine(e.Exception.ToString());
                    MessageBox.Show($"An error occurred: {e.Exception.Message}");
                }
            }
            Console.WriteLine("OnRecordingStopped end");
        }

        private void chkVoiceInput_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
