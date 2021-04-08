using System;
using System.Collections.Generic;

namespace DataMiningSystem.ClientLogic
{
    public class WorkInfo<T>
    {
        private T m_outputObject;

        private Stack<String> m_info;

        private Int32 m_maxRows;

        private const String rowsDelimiter = "\r\n";
        private const String format = "[{0}]:\t{1} - {2}";

        public Action<T, String> SettingOutputObject;

        public WorkInfo(T outputObject) : this(100, outputObject) { }

        private WorkInfo(Int32 maxRows, T outputObject)
        {
            this.m_info = new Stack<String>(maxRows);
            this.m_maxRows = maxRows;
            this.m_outputObject = outputObject;
        }

        public void AddError(String textMessage)
        {
            this.AddMessage("ERROR", textMessage);
        }

        public void AddWarning(String textMessage)
        {
            this.AddMessage("WARNING", textMessage);
        }

        public void AddInfornation(String textMessage)
        {
            this.AddMessage("INFORMATION", textMessage);
        }

        private void AddMessage(String type, String textMessage)
        {
            String sDate = DateTime.Now.ToString();
            if (this.m_info.Count >= this.m_maxRows)
            {
                this.m_info.Clear();
                this.m_info.Push(String.Format(format, "WARNING", sDate, "выполнена очистка"));
            }
            this.m_info.Push(String.Format(format, type, sDate, textMessage));

            if (this.SettingOutputObject != null && this.m_outputObject != null)
            {
                this.SettingOutputObject(this.m_outputObject, this.AddContent);
            }
        }

        public String AddContent
        {
            get
            {
                return String.Join(rowsDelimiter, this.m_info);
            }
        }
    }
}
