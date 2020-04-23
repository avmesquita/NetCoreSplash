using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSplash.App.Helpers
{
    /// <summary>
    /// https://www.learnrazorpages.com/advanced/render-partial-to-string
    /// </summary>
    public interface IRazorPartialToStringRenderer
    {
        Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
    }
}
