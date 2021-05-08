namespace Converter.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public  class ValCurs
    {

        private ValCursValute[] _valuteField;

        private string _dateField;

        private string _nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Valute")]
        public ValCursValute[] Valute
        {
            get => this._valuteField;
            set => this._valuteField = value;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Date
        {
            get => this._dateField;
            set => this._dateField = value;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get => this._nameField;
            set => this._nameField = value;
        }
    }


}