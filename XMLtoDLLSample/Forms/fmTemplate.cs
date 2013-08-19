using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XMLtoDLLSample.Configuration;
using XMLtoDLLSample.Exceptions;
using XMLtoDLLSample.Templates;

namespace XMLtoDLLSample.Forms
{
    public partial class fmTemplate : Form
    {
        private ITemplateWorker _worker;
        
        public fmTemplate()
        {
            InitializeComponent();
            Init();
        }

        protected void Init()
        {
            cmbObjects.DrawItem += new DrawItemEventHandler(cmbObjects_DrawItem);
            cmbObjects.SelectedIndexChanged += new EventHandler(cmbObjects_SelectedIndexChanged);
            cmbSpecHldrs.SelectedIndexChanged += new EventHandler(cmbSpecHldrs_SelectedIndexChanged);
            BindObjects();
            BindSpecHandlingIndicators();

            if (propertyGrid1.SelectedObject == null)
                propertyGrid1.SelectedObject = _worker.Template;
        }


        #region Combobox Objects
        private void BindObjects()
        {
            cmbObjects.DrawMode = DrawMode.OwnerDrawFixed;
            cmbObjects.Items.Clear();
            cmbObjects.DisplayMember = "Text";
            cmbObjects.ValueMember = "Value";
            cmbObjects.Items.Add(new {Text= "Product-Taylor.Current.PZManufacturing.Classes.Product.Product",Value="Product"});
            cmbObjects.Items.Add(new { Text = "ProductGroup-Taylor.Current.PZManufacturing.Classes.Product.Product", Value = "ProductGrouping" });
            cmbObjects.SelectedIndex = 0;
        }

        void cmbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string value = cmbObjects.GetSelectedValue();
            switch (value)
            {
                case "Product":
                    _worker = ProductTemplateWorker.Current;
                    break;
                case "ProductGrouping":
                    _worker = ProductGroupingTemplateWorker.Current;
                    break;
                default:
                    _worker = ProductTemplateWorker.Current;
                    break;
            }

            propertyGrid1.SelectedObject = _worker.Template;
            this.Cursor = Cursors.Default;
        }

        void cmbObjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] labels = cmbObjects.Items[e.Index].ToString().Split(new string[]{"-"},StringSplitOptions.None);

            using (SolidBrush brush = new SolidBrush(e.ForeColor))
            {
                e.DrawBackground();
                Font bold = new Font(e.Font, FontStyle.Bold);

                SizeF size = e.Graphics.MeasureString(labels[0], bold);

                RectangleF rec = new RectangleF(e.Bounds.Location, size);

                if (labels.Length > 0)
                    e.Graphics.DrawString(labels[0], bold, brush, rec);
                if (labels.Length > 1)
                    e.Graphics.DrawString(labels[1], e.Font, brush, e.Bounds.X + size.Width + 2, e.Bounds.Y);

                e.DrawFocusRectangle();
            }
        }
        #endregion

        #region Combobox Specialhandling indicator

        private void BindSpecHandlingIndicators()
        {
            cmbSpecHldrs.Items.Clear();
            cmbSpecHldrs.DisplayMember = "Text";
            cmbSpecHldrs.ValueMember = "Value";
            cmbSpecHldrs.Items.Add(new { Text = "--Select--", Value = string.Empty });

            //foreach (SpecialHandlingIndicator sh in CacheManager.Singleton.SpecialHandlingIndicators)
            //{
            //    cmbSpecHldrs.Items.Add(new { Text = sh.Description, Value = sh.SpecialHandlingIndicatorId });
            //}

            cmbSpecHldrs.Items.Add(new { Text = "SepcialHandler 1", Value = "1" });
            cmbSpecHldrs.Items.Add(new { Text = "SepcialHandler 2", Value = "2" });
            cmbSpecHldrs.Items.Add(new { Text = "SepcialHandler 3", Value = "3" });

            cmbSpecHldrs.SelectedIndex = 0;
            
            //cmbObjects.SelectedIndex = 0;
        }

        void cmbSpecHldrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cmbSpecHldrs.GetSelectedValue();
            btLoad.Enabled = !string.IsNullOrEmpty(value);
        }
        #endregion

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string spechlder = cmbSpecHldrs.GetSelectedValue();
            if (string.IsNullOrEmpty(spechlder))
            {
                MessageBox.Show(@"Please choise special handling indicator.", @"Template Setting", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            string location = null;
            string entityName = _worker.EntityName;
            
            try
            {
                location = _worker.Save(spechlder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}\r\n{1} Template could not be saved.", ex.Message, entityName), @"Template Setting",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Configuration.Configuration config = null;
            try
            {
                config = ConfigReader.Current.Read() ?? new Configuration.Configuration();
            }
            catch
            {
                config = new Configuration.Configuration();
            }

            bool isUpdated = false;

            Template template = new Template() {EntityName = _worker.EntityName, Location = location};
            TemplateSetting setting = new TemplateSetting()
            {
                SpecialHandlingIndicator = spechlder,
                Templates = new Template[] { template }
            };

            while (!isUpdated)
            {
                if (config.TemplateSettings != null)
                {
                    foreach (TemplateSetting ts in config.TemplateSettings)
                    {
                        if (ts.SpecialHandlingIndicator == spechlder)
                        {
                            foreach (Template t in ts.Templates)
                            {
                                if (t.EntityName == entityName)
                                {
                                    t.Location = location;
                                    isUpdated = true;
                                    break;
                                }
                            }

                            if (!isUpdated)
                            {
                                ts.Templates = ts.Templates.Concat(new Template[] { template }).ToArray();
                                isUpdated = true;
                                break;
                            }
                        }
                    }

                    if (!isUpdated)
                    {
                        config.TemplateSettings =
                            config.TemplateSettings.Concat(new TemplateSetting[] {setting}).ToArray();
                        isUpdated = true;
                    }
                }
                else
                {
                    config.TemplateSettings = new TemplateSetting[]{setting};
                    isUpdated = true;
                }
            }

            try
            {
                if (ConfigWriter.Current.Save(config))
                {
                    MessageBox.Show(string.Format("{0} Template is saved.", entityName), @"Template Setting",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ConfigException ex)
            {
                MessageBox.Show(string.Format("Error: {0}\\r\\n{1} Template could not be saved.", ex.Message,entityName), @"Template Setting",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            string value = cmbSpecHldrs.GetSelectedValue();
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show(@"Please choise special handling indicator.", @"Template Setting", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            bool readResource =
                MessageBox.Show(@"Do you want to load default template?", @"Template Setting", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question) == DialogResult.Yes;

            Configuration.Configuration config=null;

            if (!readResource)
            {
                try
                {
                    config = ConfigReader.Current.Read();
                }
                catch (ConfigNotFoundExcep ex)
                {
                    readResource = MessageBox.Show(
                        string.Format("INFO: {0}\r\nDo you want to load default template?", ex.Message),
                        @"Template Setting",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question)==DialogResult.Yes;
                    if (!readResource)
                        return;
                }
                catch (ConfigFailDeserializeExcep ex)
                {
                    readResource = MessageBox.Show(
                        string.Format("ERROR: {0}\r\nDo you want to load default template?", ex.Message),
                        @"Template Setting",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question) == DialogResult.Yes;
                    if(!readResource)
                        return;
                }
            }

            Template template = null;
            
            if (!readResource)
            {
                string obj = cmbObjects.GetSelectedValue();
                foreach (TemplateSetting ts in config.TemplateSettings)
                {
                    if (ts.SpecialHandlingIndicator == value)
                    {
                        foreach (Template t in ts.Templates)
                        {
                            if (t.EntityName == obj)
                            {
                                template = t;
                                break;
                            }
                        }
                    }
                }

                if (template == null)
                {
                    readResource = MessageBox.Show(
                        string.Format("INFO: {0} {1}\r\nDo you want to load default template?", obj, "Template is not existing."),
                        @"Template Setting",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question) == DialogResult.Yes;
                    if (!readResource)
                        return;
                }
            }

            if (!readResource)
            {
                try
                {
                    propertyGrid1.SelectedObject = _worker.Load(template.Location);
                    MessageBox.Show(string.Format("{0} Template loaded.", _worker.EntityName), @"Template Setting",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (TemplateException ex)
                {
                    readResource = MessageBox.Show(
                        string.Format("Error: {0}\r\nDo you want to load default template?", ex.Message),
                        @"Template Setting",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question) == DialogResult.Yes;
                    if (!readResource)
                        return;
                }
            }

            //todo default template

        }
    }
}
