/**
 * Autogenerated by Thrift Compiler (0.15.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Nebula.Storage
{

  public partial class ExecResponse : TBase
  {

    public global::Nebula.Storage.ResponseCommon Result { get; set; }

    public ExecResponse()
    {
    }

    public ExecResponse(global::Nebula.Storage.ResponseCommon result) : this()
    {
      this.Result = result;
    }

    public ExecResponse DeepCopy()
    {
      var tmp109 = new ExecResponse();
      if((Result != null))
      {
        tmp109.Result = (global::Nebula.Storage.ResponseCommon)this.Result.DeepCopy();
      }
      return tmp109;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_result = false;
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Struct)
              {
                Result = new global::Nebula.Storage.ResponseCommon();
                await Result.ReadAsync(iprot, cancellationToken);
                isset_result = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
        if (!isset_result)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp110 = new TStruct("ExecResponse");
        await oprot.WriteStructBeginAsync(tmp110, cancellationToken);
        var tmp111 = new TField();
        if((Result != null))
        {
          tmp111.Name = "result";
          tmp111.Type = TType.Struct;
          tmp111.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp111, cancellationToken);
          await Result.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is ExecResponse other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return System.Object.Equals(Result, other.Result);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Result != null))
        {
          hashcode = (hashcode * 397) + Result.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp112 = new StringBuilder("ExecResponse(");
      if((Result != null))
      {
        tmp112.Append(", Result: ");
        Result.ToString(tmp112);
      }
      tmp112.Append(')');
      return tmp112.ToString();
    }
  }

}
