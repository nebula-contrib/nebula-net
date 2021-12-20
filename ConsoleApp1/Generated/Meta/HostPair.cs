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

namespace Nebula.Meta
{

  public partial class HostPair : TBase
  {
    private global::Nebula.Common.HostAddr _from_host;
    private global::Nebula.Common.HostAddr _to_host;

    public global::Nebula.Common.HostAddr From_host
    {
      get
      {
        return _from_host;
      }
      set
      {
        __isset.from_host = true;
        this._from_host = value;
      }
    }

    public global::Nebula.Common.HostAddr To_host
    {
      get
      {
        return _to_host;
      }
      set
      {
        __isset.to_host = true;
        this._to_host = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool from_host;
      public bool to_host;
    }

    public HostPair()
    {
    }

    public HostPair DeepCopy()
    {
      var tmp941 = new HostPair();
      if((From_host != null) && __isset.from_host)
      {
        tmp941.From_host = (global::Nebula.Common.HostAddr)this.From_host.DeepCopy();
      }
      tmp941.__isset.from_host = this.__isset.from_host;
      if((To_host != null) && __isset.to_host)
      {
        tmp941.To_host = (global::Nebula.Common.HostAddr)this.To_host.DeepCopy();
      }
      tmp941.__isset.to_host = this.__isset.to_host;
      return tmp941;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
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
                From_host = new global::Nebula.Common.HostAddr();
                await From_host.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                To_host = new global::Nebula.Common.HostAddr();
                await To_host.ReadAsync(iprot, cancellationToken);
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
        var tmp942 = new TStruct("HostPair");
        await oprot.WriteStructBeginAsync(tmp942, cancellationToken);
        var tmp943 = new TField();
        if((From_host != null) && __isset.from_host)
        {
          tmp943.Name = "from_host";
          tmp943.Type = TType.Struct;
          tmp943.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp943, cancellationToken);
          await From_host.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((To_host != null) && __isset.to_host)
        {
          tmp943.Name = "to_host";
          tmp943.Type = TType.Struct;
          tmp943.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp943, cancellationToken);
          await To_host.WriteAsync(oprot, cancellationToken);
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
      if (!(that is HostPair other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.from_host == other.__isset.from_host) && ((!__isset.from_host) || (System.Object.Equals(From_host, other.From_host))))
        && ((__isset.to_host == other.__isset.to_host) && ((!__isset.to_host) || (System.Object.Equals(To_host, other.To_host))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((From_host != null) && __isset.from_host)
        {
          hashcode = (hashcode * 397) + From_host.GetHashCode();
        }
        if((To_host != null) && __isset.to_host)
        {
          hashcode = (hashcode * 397) + To_host.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp944 = new StringBuilder("HostPair(");
      int tmp945 = 0;
      if((From_host != null) && __isset.from_host)
      {
        if(0 < tmp945++) { tmp944.Append(", "); }
        tmp944.Append("From_host: ");
        From_host.ToString(tmp944);
      }
      if((To_host != null) && __isset.to_host)
      {
        if(0 < tmp945++) { tmp944.Append(", "); }
        tmp944.Append("To_host: ");
        To_host.ToString(tmp944);
      }
      tmp944.Append(')');
      return tmp944.ToString();
    }
  }

}
