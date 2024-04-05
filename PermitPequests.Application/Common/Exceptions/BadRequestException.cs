

namespace PermitPequests.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BaseResponse Response { get; }

        public BadRequestException(string message)
            : base(message)
        {
            Response = BaseResponse.BadRequest(message);
        }
    }
}
