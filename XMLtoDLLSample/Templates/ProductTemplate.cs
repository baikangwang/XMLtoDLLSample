using System.ComponentModel;
using System.Xml.Serialization;

namespace XMLtoDLLSample.Templates
{
    [DefaultProperty("ProductId")
    ,DisplayName(@"Product Template")
    ,Description("Product Template")]
    [XmlRoot]
    public class ProductTemplate : ITemplate//Product,ITemplate
    {
        #region fields

        private int _defaultColorId=1;
        private int _defaultFontId=-1;
        private int _defaultOrientationId=-1;
        private int _productionMaximum=1;
        private int _repetition=1;
        private int _systemId = 2;

        public ProductTemplate()
        {
        }

        #endregion
        #region properties

        #region Product

        /// <summary>
        /// Gets the unique identifier for this product.
        /// </summary>
        //[Category("Product"), 
        //Description("Gets the unique identifier for this product."),
        //Browsable(false)]
        //[XmlIgnore]
        //public new int ProductId { get { return base.ProductId; } }
        /// <summary>
        /// Gets and sets the product code for this product.
        /// </summary>
        [Category("Product"), 
        Description("Gets and sets the product code for this product."),
        Browsable(true)]
        [XmlElement]
        public new string ProductCode { get; set; }

        /// <summary>
        /// Gets and sets the product grouping id, which defines the actual product being produced.
        /// </summary>
        [Category("Product"), 
        Description("Gets and sets the product grouping id, which defines the actual product being produced."),
        Browsable(true)]
        [XmlElement]
        public new int ProductGroupingId { get; set; }

        /// <summary>
        /// Gets and sets the ID system where this product is produced
        /// </summary>
        [Category("Product"), 
        Description("Gets and sets the ID system where this product is produced"),
        Browsable(true)]
        [XmlElement]
        public new int SystemId { get { return _systemId; } set { _systemId = value; } }

        /// <summary>
        /// Gets the name of the system where this product is produced.
        /// </summary>
        //[Category("Product")
        //, Description("Gets the name of the system where this product is produced.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string SystemName { get { return base.SystemName; } }

        /// <summary>
        /// Gets and sets a free-text description of this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets a free-text description of this product.")
        , Browsable(true)]
        [XmlIgnore]
        public new string ProductDescription { get; set; }

        /// <summary>
        ///  Gets and sets the grouping code;
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the grouping code;")
        , Browsable(false)]
        [XmlIgnore]
        public new string GroupingCode { get; set; }

        /// <summary>
        /// Gets the description of this product's grouping.
        /// </summary>
        //[Category("Product")
        //, Description("Gets the description of this product's grouping.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string GroupingDescription
        //{
        //    get { return base.GroupingDescription; }
        //}

        /// <summary>
        /// Gets and sets the minimum number of PZ Lines allowed for this product.
        /// </summary>
        [Category("Product"), Description("Gets and sets the minimum number of PZ Lines allowed for this product."), Browsable(true)]
        [XmlElement]
        public new int MinimumPzLines { get; set; }

        /// <summary>
        /// Gets and sets the maximum number of PZ Lines allowed for this product.
        /// </summary>
        [Category("Product"), Description("Gets and sets the maximum number of PZ Lines allowed for this product."), Browsable(true)]
        [XmlElement]
        public new int MaximumPzLines { get; set; }

        /// <summary>
        /// Gets and sets the size of the product, which is usually the number of individual items.
        /// </summary>
        [Category("Product"), Description("Gets and sets the size of the product, which is usually the number of individual items."), Browsable(true)]
        [XmlElement]
        public new int ProductSize { get; set; }

        /// <summary>
        /// Gets and sets the repetition for this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the repetition for this product.")
        , Browsable(true)]
        [XmlElement]
        public new int Repetition
        {
            get { return _repetition; }
            set { _repetition = value; }
        }

        /// <summary>
        /// Gets and sets the number of product pages associated with this product.
        /// </summary>
        [Category("Product"), Description("Gets and sets the number of product pages associated with this product."), Browsable(true)]
        [XmlElement]
        public new int ProductPageCount { get; set; }

        /// <summary>
        /// Gets and sets license copy, line 1, which is the Copyright, which is also the Advertised SKU
        /// </summary>
        [Category("Product")
        , Description("Gets and sets license copy, line 1, which is the Copyright, which is also the Advertised SKU")
        , Browsable(false)]
        [XmlIgnore]
        public new string LicenseCopy { get; set; }

        /// <summary>
        /// Gets and sets license copy, line 2, which is the Copyright Company
        /// </summary>
        [Category("Product")
        , Description("Gets and sets license copy, line 2, which is the Copyright Company")
        , Browsable(false)]
        [XmlIgnore]
        public new string LicenseCopy2 { get; set; }

        /// <summary>
        /// Gets and sets component information.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets component information.")
        , Browsable(true)]
        [XmlElement]
        public new string ComponentInformation { get; set; }

        //[Category("Product")
        //, Description("Gets and sets component location information.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string ComponentLocationInformation
        //{
        //    get { return base.ComponentLocationInformation; }
        //}

        /// <summary>
        /// Gets and sets the ID of the default color for this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the ID of the default color for this product.")
        , Browsable(true)]
        [XmlElement]
        public new int DefaultColorId
        {
            get { return _defaultColorId; }
            set { _defaultColorId = value; }
        }

        /// <summary>
        /// Gets the default color for this product.
        /// </summary>
        //[Category("Product")
        //, Description("Gets the default color for this product.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string DefaultColor { get { return base.DefaultColor; } }

        /// <summary>
        /// Gets and sets the ID of the default orientation for this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the ID of the default orientation for this product.")
        , Browsable(true)]
        [XmlElement]
        public new int DefaultOrientationId
        {
            get { return _defaultOrientationId; }
            set { _defaultOrientationId = value; }
        }

        /// <summary>
        /// Gets and setsthe orientation for this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and setsthe orientation for this product.")
        , Browsable(false)]
        [XmlIgnore]
        public new string Orientation { get; set; }

        /// <summary>
        /// Gets the orientation code for this product.
        /// </summary>
        //[Category("Product")
        //, Description("Gets the orientation code for this product.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string OrientationCode
        //{
        //    get { return base.OrientationCode; }
        //}

        /// <summary>
        /// Gets and sets the layout code.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the layout code.")
        , Browsable(false)]
        [XmlIgnore]
        public new string LayoutCode { get; set; }

        /// <summary>
        /// Gets and sets any instructions specific to this product.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets any instructions specific to this product.")
        , Browsable(true)]
        [XmlElement]
        public new string Instructions { get; set; }

        /// <summary>
        /// Gets and sets a value indicating the minimum numbe of products that can be produced together.
        /// </summary>
        [Category("Product"), Description("Gets and sets a value indicating the minimum numbe of products that can be produced together."), Browsable(true)]
        [XmlElement]
        public new int ProductionMinimum { get; set; }

        /// <summary>
        /// Gets and sets a value indicating the maximum number of products that can be produced together.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets a value indicating the maximum number of products that can be produced together.")
        , Browsable(true)]
        [XmlElement]
        public new int ProductionMaximum
        {
            get { return _productionMaximum; }
            set { _productionMaximum = value; }
        }

        /// <summary>
        /// Gets and sets a value indicating whether this product is disabled or not.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets a value indicating whether this product is disabled or not.")
        , Browsable(false)]
        [XmlIgnore]
        public new bool IsDisabled { get; set; }

        /// <summary>
        /// Gets and sets a value indicating whether this product is out of stock or not.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets a value indicating whether this product is out of stock or not.")
        , Browsable(false)]
        [XmlIgnore]
        public new bool IsOutOfStock { get; set; }

        /// <summary>
        /// Gets and sets a value indicating whether this product is on hold or not.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets a value indicating whether this product is on hold or not.")
        , Browsable(false)]
        [XmlIgnore]
        public new bool IsOnHold { get; set; }

        /// <summary>
        /// Gets and sets the reason why this product is on hold.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the reason why this product is on hold.")
        , Browsable(false)]
        [XmlIgnore]
        public new string HoldReason { get; set; }

        /// <summary>
        /// Gets and sets the special handling flag.
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the special handling flag.")
        , Browsable(true)]
        [XmlElement]
        public new int SpecialHandlingId { get; set; }

        //[Category("Product")
        //, Description("Gets special handling indicator")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new SpecialHandlingIndicator SpecialHandlingIndicator { get { return base.SpecialHandlingIndicator; } }
        /// <summary>
        /// Gets and sets the ShippingMethodId that this Product will ship by (unless it's merged, one of the TreatAsRush or employee order, secondary to ProductGrouping.ForceShippingMethodId)
        /// </summary>
        [Category("Product")
        , Description("Gets and sets the ShippingMethodId that this Product will ship by (unless it's merged, one of the TreatAsRush or employee order, secondary to ProductGrouping.ForceShippingMethodId)")
        , Browsable(false)]
        [XmlIgnore]
        public new int ForceShippingMethodId { get; set; }
        
        [Category("Product")
        , Description("Gets and sets default font family")
        , Browsable(true)]
        [XmlElement]
        public new int DefaultFontId
        {
            get { return _defaultFontId; }
            set { _defaultFontId = value; }
        }

        [Category("Product")
        , Description("Gets and sets default font family")
        , Browsable(false)]
        [XmlIgnore]
        public new string DefaultFont { get; set; }

        [Category("Product")
        , Description("Gets and sets default font ICSM code")
        , Browsable(false)]
        [XmlIgnore]
        public new string DefaultFontICSMCode { get; set; }

        //[Category("Product")
        //, Description("Gets components of this product")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new List<ProductComponent> ProductComponents { get { return base.ProductComponents; } }

        #endregion

        #region Base

        /// <summary>
        /// Gets and sets whether this instance was successfully read from the data row or not.
        /// </summary>
        //[Category("Base")
        //, Description("Gets and sets whether this instance was successfully read from the data row or not.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new bool IsValid { get { return isValid; } set { isValid = value; } }
        /// <summary>
        /// Gets and sets an error message associated with this instance, not necessarily the same as what is stored in the database.
        /// </summary>
        //[Category("Base")
        //, Description("Gets and sets an error message associated with this instance, not necessarily the same as what is stored in the database.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string ErrorMessage { get { return errorMessage ?? ""; } set { errorMessage = value; } }
        /// <summary>
        /// Gets and sets whether this instance is marked as deleted or not.
        /// </summary>
        //[Category("Base")
        //, Description("Gets and sets whether this instance is marked as deleted or not.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new bool IsDeleted { get { return isDeleted; } set { isDeleted = value; } }
        /// <summary>
        /// Gets and sets the account ID of the entity who last modified the row behind this instance.
        /// </summary>
        //[Category("Base")
        //, Description("Gets and sets the account ID of the entity who last modified the row behind this instance.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new int ModifiedById { get { return modifiedById; } set { modifiedById = value; } }
        /// <summary>
        /// Gets the name of the entity who last modified the row behind this instance, automatically set when inserting/updating.
        /// </summary>
        //[Category("Base")
        //, Description("Gets the name of the entity who last modified the row behind this instance, automatically set when inserting/updating.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new string ModifiedByName { get { return modifiedByName; } }
        /// <summary>
        /// Gets the date when the row behind this instance was last modified, automatically set when inserting/updating.
        /// </summary>
        //[Category("Base")
        //, Description("Gets the date when the row behind this instance was last modified, automatically set when inserting/updating.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new DateTime ModifiedDate { get { return modifiedDate; } }
        /// <summary>
        /// Gets the row stamp, which identifies the version of the row in the database.
        /// </summary>
        //[Category("Base")
        //, Description("Gets the row stamp, which identifies the version of the row in the database.")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new byte[] RowStamp { get { return rowStamp; } }

        //[Category("Base")
        //, Description("Gets and sets Tag")
        //, Browsable(false)]
        //[XmlIgnore]
        //public new object Tag { get; set; }
        
        #endregion

        #endregion
    }

    public class ProductGroupTemplate : /*ProductGrouping,*/ ITemplate
    {
    }
}
