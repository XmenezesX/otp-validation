using OTPValidation.Core.Shared.Infrastructure.CrossCutting.NotificationError;

namespace OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation
{
    public enum ErrorType
    {
        ValidationError = 1,
        DataBaseError = 2,
        CacheError = 3,
        BusinessError = 4,
        InternalError = 5,
        UndefinedError = 6,
        ExceptionError = 7,
        ProviderError = 8,
        EntityNotFound = 9,
    }

    public interface IOperation
    {
    }

    public interface IOperation<T> : IOperation
    {
    }

    public interface IOperationSuccess : IOperation
    {
    }

    public interface IOperationSuccess<T> : IOperationSuccess, IOperation<T>
    {
        T Data { get; init; }
    }

    public interface IOperationFail : IOperation
    {
        NotificationErrors NotificationErrors { get; init; }
        ErrorType ErrorType { get; init; }
    }

    public interface IOperationFail<T> : IOperationFail, IOperation<T>
    {
    }

    internal class OperationSuccess<T>(T result) : IOperationSuccess<T>
    {
        public T Data { get; init; } = result;


       
    }

    internal class OperationFail<T> : IOperationFail<T>
    {
        public OperationFail(NotificationErrors notificationErrors, ErrorType errorType)
        {
            NotificationErrors = notificationErrors;
            ErrorType = errorType;
        }

        public NotificationErrors NotificationErrors { get; init; }

        public string ErrorTypeDescription => ErrorType.ToString();

        public ErrorType ErrorType { get; init; }
    }

    public static class OperationFactory
    {
        public static IOperationSuccess CreateSuccess()
        {
            return new OperationSuccess<object>(null!);
        }

        private static readonly IOperationSuccess ImmutableSucces = new OperationSuccess<object>(null!);
        public static IOperationSuccess CreateImmutableSuccess()
        {
            return ImmutableSucces;
        }

        public static IOperationFail CreateFail(NotificationErrors notificationErrors)
        {
            return new OperationFail<object>(notificationErrors, ErrorType.UndefinedError);
        }

        public static IOperationFail CreateFail(NotificationErrors notificationErrors, ErrorType errorType)
        {
            return new OperationFail<object>(notificationErrors, errorType);
        }

        public static IOperationFail CreateFail()
        {
            return new OperationFail<object>(NotificationErrors.Empty, ErrorType.UndefinedError);
        }

        public static IOperationSuccess<T> CreateSuccess<T>(T data)
        {
            return new OperationSuccess<T>(data);
        }

        public static IOperationSuccess<T> CreateSuccess<T>()
        {
            return new OperationSuccess<T>(default);
        }

        public static IOperationFail CreateFail(Exception exception)
        {
            return new OperationFail<object>(NotificationErrors.Create(exception), ErrorType.ExceptionError);
        }

        public static IOperationFail CreateFail(ErrorType errorType)
        {
            return new OperationFail<object>(NotificationErrors.Empty, errorType);
        } 

        public static IOperationFail<T> CreateFail<T>(Exception exception)
        {
            return new OperationFail<T>(NotificationErrors.Create(exception), ErrorType.ExceptionError);
        }

        public static IOperationFail<T> CreateFail<T>(NotificationErrors notificationErrors)
        {
            return new OperationFail<T>(notificationErrors, ErrorType.UndefinedError);
        }

        public static IOperationFail<T> CreateFail<T>(NotificationErrors notificationErrors, ErrorType errorType)
        {
            return new OperationFail<T>(notificationErrors, errorType);
        }

        public static IOperationFail<T> CreateFail<T>()
        {
            return new OperationFail<T>(NotificationErrors.Empty, ErrorType.UndefinedError);
        }

        public static IOperationFail<T> CreateFail<T>(IOperationFail operationFail)
        {
            return CreateFail<T>(operationFail.NotificationErrors, operationFail.ErrorType);
        }
    }


    public static class OperationExtends
    {
       
        public static Dictionary<string, object> SucessAsDictonary(this IOperation operation)
        {
            if(operation is IOperationSuccess<Dictionary<string,object>> operationDir)
            {
                return operationDir.Data;
            }

            return (((operation as IOperationSuccess<object>)!.Data) as Dictionary<string, object>)!;
        }

        public static T SucessAs<T>(this IOperation operation)
        {
            return ((operation as IOperationSuccess<T>)!.Data);
        }

        public static bool IsFail(this IOperation operation, params ErrorType[] notInclude)
        {
            var fail = (operation as IOperationFail);
            if (fail is null)
                return false;

            if(notInclude.Contains(fail.ErrorType))
                return false;

            return true;

        }

        public static bool IsSuccess(this IOperation operation)
        {
            var success = (operation as IOperationSuccess);
            if (success is null)
                return false;

            return true;

        }

        public static bool IsEntityNotFound(this IOperation operation)
        {
            var fail = (operation as IOperationFail);
            return fail != null && fail.ErrorType == ErrorType.EntityNotFound;
        }

        public static IOperationFail AsFail(this IOperation operation)
        {
            return (IOperationFail)operation;
        }

        public static IOperationFail<T> AsFail<T>(this IOperation<T> operation)
        {
            return (IOperationFail<T>)operation;
        }

        public static IOperationFail<T> AsFail<T>(this IOperation operation)
        {
            return OperationFactory.CreateFail<T>(operation.AsFail());
        }

        public static IOperationSuccess<T> AsSuccess<T>(this T obj)
        {
            return OperationFactory.CreateSuccess<T>((T)obj);
        }
    }
}

