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

  public partial class GetGroupResp : TBase
  {
    private global::Nebula.Common.ErrorCode _code;
    private global::Nebula.Common.HostAddr _leader;
    private List<byte[]> _zone_names;

    /// <summary>
    /// 
    /// <seealso cref="global::Nebula.Common.ErrorCode"/>
    /// </summary>
    public global::Nebula.Common.ErrorCode Code
    {
      get
      {
        return _code;
      }
      set
      {
        __isset.code = true;
        this._code = value;
      }
    }

    public global::Nebula.Common.HostAddr Leader
    {
      get
      {
        return _leader;
      }
      set
      {
        __isset.leader = true;
        this._leader = value;
      }
    }

    public List<byte[]> Zone_names
    {
      get
      {
        return _zone_names;
      }
      set
      {
        __isset.zone_names = true;
        this._zone_names = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool code;
      public bool leader;
      public bool zone_names;
    }

    public GetGroupResp()
    {
    }

    public GetGroupResp DeepCopy()
    {
      var tmp821 = new GetGroupResp();
      if(__isset.code)
      {
        tmp821.Code = this.Code;
      }
      tmp821.__isset.code = this.__isset.code;
      if((Leader != null) && __isset.leader)
      {
        tmp821.Leader = (global::Nebula.Common.HostAddr)this.Leader.DeepCopy();
      }
      tmp821.__isset.leader = this.__isset.leader;
      if((Zone_names != null) && __isset.zone_names)
      {
        tmp821.Zone_names = this.Zone_names.DeepCopy();
      }
      tmp821.__isset.zone_names = this.__isset.zone_names;
      return tmp821;
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
              if (field.Type == TType.I32)
              {
                Code = (global::Nebula.Common.ErrorCode)await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                Leader = new global::Nebula.Common.HostAddr();
                await Leader.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.List)
              {
                {
                  TList _list822 = await iprot.ReadListBeginAsync(cancellationToken);
                  Zone_names = new List<byte[]>(_list822.Count);
                  for(int _i823 = 0; _i823 < _list822.Count; ++_i823)
                  {
                    byte[] _elem824;
                    _elem824 = await iprot.ReadBinaryAsync(cancellationToken);
                    Zone_names.Add(_elem824);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
        var tmp825 = new TStruct("GetGroupResp");
        await oprot.WriteStructBeginAsync(tmp825, cancellationToken);
        var tmp826 = new TField();
        if(__isset.code)
        {
          tmp826.Name = "code";
          tmp826.Type = TType.I32;
          tmp826.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp826, cancellationToken);
          await oprot.WriteI32Async((int)Code, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Leader != null) && __isset.leader)
        {
          tmp826.Name = "leader";
          tmp826.Type = TType.Struct;
          tmp826.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp826, cancellationToken);
          await Leader.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Zone_names != null) && __isset.zone_names)
        {
          tmp826.Name = "zone_names";
          tmp826.Type = TType.List;
          tmp826.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp826, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.String, Zone_names.Count), cancellationToken);
            foreach (byte[] _iter827 in Zone_names)
            {
              await oprot.WriteBinaryAsync(_iter827, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
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
      if (!(that is GetGroupResp other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.code == other.__isset.code) && ((!__isset.code) || (System.Object.Equals(Code, other.Code))))
        && ((__isset.leader == other.__isset.leader) && ((!__isset.leader) || (System.Object.Equals(Leader, other.Leader))))
        && ((__isset.zone_names == other.__isset.zone_names) && ((!__isset.zone_names) || (TCollections.Equals(Zone_names, other.Zone_names))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.code)
        {
          hashcode = (hashcode * 397) + Code.GetHashCode();
        }
        if((Leader != null) && __isset.leader)
        {
          hashcode = (hashcode * 397) + Leader.GetHashCode();
        }
        if((Zone_names != null) && __isset.zone_names)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Zone_names);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp828 = new StringBuilder("GetGroupResp(");
      int tmp829 = 0;
      if(__isset.code)
      {
        if(0 < tmp829++) { tmp828.Append(", "); }
        tmp828.Append("Code: ");
        Code.ToString(tmp828);
      }
      if((Leader != null) && __isset.leader)
      {
        if(0 < tmp829++) { tmp828.Append(", "); }
        tmp828.Append("Leader: ");
        Leader.ToString(tmp828);
      }
      if((Zone_names != null) && __isset.zone_names)
      {
        if(0 < tmp829++) { tmp828.Append(", "); }
        tmp828.Append("Zone_names: ");
        Zone_names.ToString(tmp828);
      }
      tmp828.Append(')');
      return tmp828.ToString();
    }
  }

}
