namespace XMLtoDLLSample.Templates
{
    public class ProductTemplateWorker:TemplateWorker<ProductTemplate>
    {
        private static ProductTemplateWorker _singleton=new ProductTemplateWorker();

        public static ProductTemplateWorker Current
        {
            get { return _singleton; }
        }
        
        protected ProductTemplateWorker()
        {

        }


        public override string EntityName
        {
            get { return "Product"; }
        }
    }
}
