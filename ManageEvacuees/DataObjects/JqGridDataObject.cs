using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ManageEvacuees.DataObjects
{
    public class JqGridResult<T>
    {
        public JqGridDataObject<T> jqGridDataObject { get; set; }
        public GroupHeaders groupHeaders { get; set; }
        public string errorMessage { get; set; }
    }

    public class JqGridDataObject<T>
    {
        /*
        datatype: 'json',
        datastr: serverResponse,
        colNames: ['FirstName', 'LastName', 'Age'],
        colModel: [
            { name: 'FirstName', index: 'FirstName', width: 55, sorttype: 'string' },
            { name: 'LastName', index: 'LastName', width: 90, sorttype: 'string' },
            { name: 'Age', index: 'Age', width: 80, align: 'right', sorttype: 'string'}],
        pager: '#pager',
        rowNum: 10,
        viewrecords: true,
        direction: "rtl"
         */


        /// <summary>
        /// Total number of pages
        /// </summary>
        public int totalPagesNumber { get; set; }

        /// <summary>
        /// The current page number
        /// </summary>
        public int pageNumber { get; set; }

        ///// <summary>
        ///// Total number of records
        ///// </summary>
        //public int columnNumber { get; set; }

        private string _datatype;
        public string datatype {
            get
            {
                if (string.IsNullOrEmpty(_datatype))
                {
                    return "jsonstring";
                }
                return _datatype;
            }
            set
            {
                _datatype = value;
            }
        }
        
        /// <summary>
        /// The actual data
        /// </summary>
        public List<T> datastr { get; set; }

        ///// <summary>
        ///// The actual data parsed to json string
        ///// </summary>
        //public string datastr
        //{
        //    get
        //    {
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        return js.Serialize(this.data);
        //    }
        //}

        /// <summary>
        /// The Captions text
        /// </summary>
        public List<string> colNames { get; set; }

        public List<JqGridColModel> colModel { get; set; }

        private string _pager;
        public string pager
        {
            get
            {
                if (string.IsNullOrEmpty(_pager))
                {
                    return "#pager";
                }
                return _pager;
            }
            set
            {
                _pager = value;
            }
        }

        private int? _rowNum;
        public int rowNum
        {
            get
            {
                if (!_rowNum.HasValue)
                {
                    return 10;
                }
                return _rowNum.Value;
            }
            set
            {
                _rowNum = value;
            }
        }

        private bool? _viewrecords;
        public bool viewrecords
        {
            get
            {
                if (!_viewrecords.HasValue)
                {
                    return true;
                }
                return _viewrecords.Value;
            }
            set
            {
                _viewrecords = value;
            }
        }

        private bool? _loadonce;
        public bool loadonce
        {
            get
            {
                if (!_loadonce.HasValue)
                {
                    return true;
                }
                return _loadonce.Value;
            }
            set
            {
                _loadonce = value;
            }
        }

        private string _direction;
        public string direction
        {
            get
            {
                if (string.IsNullOrEmpty(_direction))
                {
                    return "rtl";
                }
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        private string _height;
        public string height
        {
            get
            {
                if (string.IsNullOrEmpty(_height))
                {
                    return "auto";
                }
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        //public JsonReader jsonReader 
        //{
        //    get
        //    { return new JsonReader(); }
        //}
    }

    public class GroupHeaders
    {
        public bool useColSpanStyle
        {
            get
            {
                return true;
            }
        }

        public List<GroupHeader> groupHeaders { get; set; }
    }

    public class GroupHeader
    {
        public string startColumnName { get; set; }
        public int numberOfColumns { get; set; }
        public string titleText { get; set; }
    }

//    public class JsonReader
//    {
//        /*
//         jsonReader: {
//    repeatitems: false,
//    root: function (obj) { return obj; },
//    page: function (obj) { return 1; },
//    total: function (obj) { return 1; },
//    records: function (obj) { return obj.length; }
//}
//         */
//        public bool repeatitems { get { return false; } },
//        public
//    }

}