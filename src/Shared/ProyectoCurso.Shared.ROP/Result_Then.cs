using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCurso.Shared.ROP
{
    public static class Result_Then
    {
    public static Result<T> Then<T>(this Result<T> r, Action<T> action)
    {
        try
        {
            if (r.Success)
            {
                action(r.Value);
            }

            return r;
        }
        catch (Exception e)
        {
            ExceptionDispatchInfo.Capture(e).Throw();
            throw;
        }
    }

    public static async Task<Result<T>> Then<T>(this Task<Result<T>> result, Action<T> action)
    {
        try
        {
            var r = await result;
            if (r.Success)
            {
                action(r.Value);
            }

            return r;
        }
        catch (Exception e)
        {
            ExceptionDispatchInfo.Capture(e).Throw();
            throw;
        }
    }
    }
}
