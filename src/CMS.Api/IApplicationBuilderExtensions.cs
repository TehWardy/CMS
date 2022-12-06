namespace CMS.Api
{
    public static class IApplicationBuilderExtensions
    {
        private static bool initialized = false;

        public static void UseCMS(this IApplicationBuilder app)
        {
            if(!initialized)
            {
                initialized = true;
                //app.ApplicationServices.GetService<IEventHub>();

                //TODO: setup event subs here
            }
        }
    }
}
