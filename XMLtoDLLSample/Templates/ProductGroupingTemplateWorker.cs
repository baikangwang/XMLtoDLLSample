namespace XMLtoDLLSample.Templates
{
    public class ProductGroupingTemplateWorker : TemplateWorker<ProductGroupTemplate>
    {
        private static ProductGroupingTemplateWorker _singleton=new ProductGroupingTemplateWorker();

        public static ProductGroupingTemplateWorker Current
        {
            get { return _singleton; }
        }

        protected ProductGroupingTemplateWorker()
        {

        }
        
        public override string EntityName
        {
            get { return "ProductGrouping"; }
        }
    }
}
