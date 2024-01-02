using System.Net;
using TodoApi.Codes;

namespace TodoApi.Domains.Common;

public class ResponseMessageBuilder<T>
{
    public ResponseMessage<T> message = new ResponseMessage<T>();

    public ResponseMessageBuilder()
    {
        message.Code = ResultEnum.Success;
    }

    public ResponseMessageBuilder<T> AddCode(ResultEnum code)
    {
        message.Code = code;
        return this;
    }

    /// <summary>
    /// 싱글 데이터 추가
    /// </summary>
    /// <param name="datas"></param>
    /// <returns></returns>
    public ResponseMessageBuilder<T> AddData(T datas)
    {
        if(message.Datas == null)
            message.Datas = new List<T> {datas};

        return this;
    }

    /// <summary>
    /// List 데이터 추가
    /// </summary>
    /// <param name="datas"></param>
    /// <returns></returns>
    public ResponseMessageBuilder<T> AddDatas(IReadOnlyList<T> datas)
    {
        message.Datas = datas;
        return this;
    }

    public ResponseMessageBuilder<T> AddError(string error)
    {
        if(message.Errors == null)
            message.Errors = new List<string>();
        message.Errors.Add(error);
        return this;
    }

    public ResponseMessage<T> Build()
    {
        return message;
    }
}

public class ResponseMessage<T>
{
    public ResultEnum Code {get; set;}
    public ICollection<string>? Errors {get; set;}
    public IReadOnlyList<T>? Datas {get; set;}
}