namespace Converter.Model
{
    [System.SerializableAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ValCursValute
    {

        private ushort _numCodeField;

        private string _charCodeField;

        private ushort _nominalField;

        private string _nameField;

        private string _valueField;

        //private string[] _textField;

        private string _idField;

        /// <remarks/>
        public ushort NumCode
        {
            get => this._numCodeField;
            set => this._numCodeField = value;
        }

        /// <remarks/>
        public string CharCode
        {
            get => this._charCodeField;
            set => this._charCodeField = value;
        }

        /// <remarks/>
        public ushort Nominal
        {
            get => this._nominalField;
            set => this._nominalField = value;
        }

        /// <remarks/>
        public string Name
        {
            get => this._nameField;
            set => this._nameField = value;
        }

        /// <remarks/>
        
        public string Value
        {
            get => this._valueField;
            set => this._valueField = value;
        }

        ///// <remarks/>
        // [System.Xml.Serialization.XmlTextAttribute()]
        // public string[] Text
        // {
        //     get => this._textField;
        //     set => this._textField = value;
        // }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get => this._idField;
            set => this._idField = value;
        }
    }
}