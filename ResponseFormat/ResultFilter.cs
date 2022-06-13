using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ResponseFormat;

public class ResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        //throw new NotImplementedException();
        context.Result = new JsonResult(new Result());
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        //throw new NotImplementedException();
    }
}