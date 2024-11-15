﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace CodeTorch.Core
{

    [Serializable]
    public class BaseRestServiceMethod
    {
        List<ScreenDataCommand> _commands = new List<ScreenDataCommand>();

        RestServiceResponseMode _ResponseMode = RestServiceResponseMode.Default;
        bool _EnablePartialResponse = true;
        string _PartialResponseParameter = "fields";

        string _PagingOffsetParameter = "offset";
        string _PagingLimitParameter = "limit";
        int _PagingLimitDefault = 20;

        [XmlIgnore()]
        [Browsable(false)]
        public RestService ParentService { get; set; }

        [XmlArray("DataCommands")]
        [XmlArrayItem("DataCommand")]
        [Description("List of page specific datacommands and their input settings")]
        [Category("Data")]
        [Editor("CodeTorch.Core.Design.ScreenDataCommandCollectionEditor,CodeTorch.Core.Design", typeof(UITypeEditor))]
        public virtual List<ScreenDataCommand> DataCommands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
            }

        }

        [ReadOnly(true)]
        [Category("Common")]
        public RestServiceMethodActionEnum Action { get; set; }

        [Category("Data")]
        [TypeConverter("CodeTorch.Core.Design.DataCommandTypeConverter,CodeTorch.Core.Design")]
        public string RequestDataCommand { get; set; }

        
        [Description("Field to return verbatim as content of web service call - any format")]
        [TypeConverter("CodeTorch.Core.Design.DataCommandColumnTypeConverter,CodeTorch.Core.Design")]
        public string RawDataField { get; set; }

        [Description("CSV of fields that contain raw JSON data and should be returned natively as part of the json message instead of escaping as strings")]
        public string RawJsonFields { get; set; }

        [Category("Partial Response")]
        public bool EnablePartialResponse
        {
            get { return _EnablePartialResponse; }
            set { _EnablePartialResponse = value; }
        }

        
        [Category("Partial Response")]
        public string PartialResponseParameter
        {
            get { return _PartialResponseParameter; }
            set { _PartialResponseParameter = value; }
        }

        [Category("Partial Response")]
        public string PartialResponseDefaultFields { get; set; }

        [Category("Pagination")]
        public bool EnablePaging { get; set; }


        [Category("Pagination")]
        public bool EnableDefaultLimit { get; set; }
        
        [Category("Pagination")]
        public string PagingOffsetParameter
        {
            get { return _PagingOffsetParameter; }
            set { _PagingOffsetParameter = value; }
        }

        [Category("Pagination")]
        public string PagingLimitParameter
        {
            get { return _PagingLimitParameter; }
            set { _PagingLimitParameter = value; }
        }

        [Category("Pagination")]
        public int PagingLimitDefault
        {
            get { return _PagingLimitDefault; }
            set { _PagingLimitDefault = value; }
        }

        public RestServiceMethodReturnTypeEnum ReturnType { get; set; }

        public string ExcludeParametersFromLogging { get; set; }

        public RestServiceResponseMode ResponseMode
        { 
            get { return _ResponseMode; }
            set { _ResponseMode = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Action, RequestDataCommand);
        }
    }
}
