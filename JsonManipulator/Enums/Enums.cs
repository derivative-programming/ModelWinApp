using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonManipulator.Enums
{
    public enum ButtonType
    {
        REPORT,
        FORM
    }
    public enum FormObjects
    {
       FORM,
       DBBJECT,
       REPORT,
       REPORT_CHILD,
       DBOBJECT_RPT_DETAIL,
       RPT_DETAIL_ROLE,
       DBBJECT_EDIT,
       DBBJECT_ADD,
       REPORT_SETT,
       REPORT_ROLE,
       REPORT_BUTTON,
       REPORT_COLUMNS,
       OBJECT_EDIT,
       ADD_FLOW
    }
    public enum Booleans
    {
        TRUE,
        FALSE
    }
    public enum ParentType
    {
        ADD,
        EDIT,
        REPORT_BUTTON
    }
    public enum NodeType
    {
        OBJECT,
        FORM,
        REPORT
    }
}
