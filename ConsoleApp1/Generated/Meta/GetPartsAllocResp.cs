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

  public partial class GetPartsAllocResp : TBase
  {
    private global::Nebula.Common.ErrorCode _code;
    private global::Nebula.Common.HostAddr _leader;
    private Dictionary<int, List<global::Nebula.Common.HostAddr>> _parts;
    private Dictionary<int, long> _terms;

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

    public Dictionary<int, List<global::Nebula.Common.HostAddr>> Parts
    {
      get
      {
        return _parts;
      }
      set
      {
        __isset.parts = true;
        this._parts = value;
      }
    }

    public Dictionary<int, long> Terms
    {
      get
      {
        return _terms;
      }
      set
      {
        __isset.terms = true;
        this._terms = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool code;
      public bool leader;
      public bool parts;
      public bool terms;
    }

    public GetPartsAllocResp()
    {
    }

    public GetPartsAllocResp DeepCopy()
    {
      var tmp359 = new GetPartsAllocResp();
      if(__isset.code)
      {
        tmp359.Code = this.Code;
      }
      tmp359.__isset.code = this.__isset.code;
      if((Leader != null) && __isset.leader)
      {
        tmp359.Leader = (global::Nebula.Common.HostAddr)this.Leader.DeepCopy();
      }
      tmp359.__isset.leader = this.__isset.leader;
      if((Parts != null) && __isset.parts)
      {
        tmp359.Parts = this.Parts.DeepCopy();
      }
      tmp359.__isset.parts = this.__isset.parts;
      if((Terms != null) && __isset.terms)
      {
        tmp359.Terms = this.Terms.DeepCopy();
      }
      tmp359.__isset.terms = this.__isset.terms;
      return tmp359;
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
              if (field.Type == TType.Map)
              {
                {
                  TMap _map360 = await iprot.ReadMapBeginAsync(cancellationToken);
                  Parts = new Dictionary<int, List<global::Nebula.Common.HostAddr>>(_map360.Count);
                  for(int _i361 = 0; _i361 < _map360.Count; ++_i361)
                  {
                    int _key362;
                    List<global::Nebula.Common.HostAddr> _val363;
                    _key362 = await iprot.ReadI32Async(cancellationToken);
                    {
                      TList _list364 = await iprot.ReadListBeginAsync(cancellationToken);
                      _val363 = new List<global::Nebula.Common.HostAddr>(_list364.Count);
                      for(int _i365 = 0; _i365 < _list364.Count; ++_i365)
                      {
                        global::Nebula.Common.HostAddr _elem366;
                        _elem366 = new global::Nebula.Common.HostAddr();
                        await _elem366.ReadAsync(iprot, cancellationToken);
                        _val363.Add(_elem366);
                      }
                      await iprot.ReadListEndAsync(cancellationToken);
                    }
                    Parts[_key362] = _val363;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.Map)
              {
                {
                  TMap _map367 = await iprot.ReadMapBeginAsync(cancellationToken);
                  Terms = new Dictionary<int, long>(_map367.Count);
                  for(int _i368 = 0; _i368 < _map367.Count; ++_i368)
                  {
                    int _key369;
                    long _val370;
                    _key369 = await iprot.ReadI32Async(cancellationToken);
                    _val370 = await iprot.ReadI64Async(cancellationToken);
                    Terms[_key369] = _val370;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
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
        var tmp371 = new TStruct("GetPartsAllocResp");
        await oprot.WriteStructBeginAsync(tmp371, cancellationToken);
        var tmp372 = new TField();
        if(__isset.code)
        {
          tmp372.Name = "code";
          tmp372.Type = TType.I32;
          tmp372.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp372, cancellationToken);
          await oprot.WriteI32Async((int)Code, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Leader != null) && __isset.leader)
        {
          tmp372.Name = "leader";
          tmp372.Type = TType.Struct;
          tmp372.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp372, cancellationToken);
          await Leader.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Parts != null) && __isset.parts)
        {
          tmp372.Name = "parts";
          tmp372.Type = TType.Map;
          tmp372.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp372, cancellationToken);
          {
            await oprot.WriteMapBeginAsync(new TMap(TType.I32, TType.List, Parts.Count), cancellationToken);
            foreach (int _iter373 in Parts.Keys)
            {
              await oprot.WriteI32Async(_iter373, cancellationToken);
              {
                await oprot.WriteListBeginAsync(new TList(TType.Struct, Parts[_iter373].Count), cancellationToken);
                foreach (global::Nebula.Common.HostAddr _iter374 in Parts[_iter373])
                {
                  await _iter374.WriteAsync(oprot, cancellationToken);
                }
                await oprot.WriteListEndAsync(cancellationToken);
              }
            }
            await oprot.WriteMapEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Terms != null) && __isset.terms)
        {
          tmp372.Name = "terms";
          tmp372.Type = TType.Map;
          tmp372.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp372, cancellationToken);
          {
            await oprot.WriteMapBeginAsync(new TMap(TType.I32, TType.I64, Terms.Count), cancellationToken);
            foreach (int _iter375 in Terms.Keys)
            {
              await oprot.WriteI32Async(_iter375, cancellationToken);
              await oprot.WriteI64Async(Terms[_iter375], cancellationToken);
            }
            await oprot.WriteMapEndAsync(cancellationToken);
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
      if (!(that is GetPartsAllocResp other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.code == other.__isset.code) && ((!__isset.code) || (System.Object.Equals(Code, other.Code))))
        && ((__isset.leader == other.__isset.leader) && ((!__isset.leader) || (System.Object.Equals(Leader, other.Leader))))
        && ((__isset.parts == other.__isset.parts) && ((!__isset.parts) || (TCollections.Equals(Parts, other.Parts))))
        && ((__isset.terms == other.__isset.terms) && ((!__isset.terms) || (TCollections.Equals(Terms, other.Terms))));
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
        if((Parts != null) && __isset.parts)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Parts);
        }
        if((Terms != null) && __isset.terms)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Terms);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp376 = new StringBuilder("GetPartsAllocResp(");
      int tmp377 = 0;
      if(__isset.code)
      {
        if(0 < tmp377++) { tmp376.Append(", "); }
        tmp376.Append("Code: ");
        Code.ToString(tmp376);
      }
      if((Leader != null) && __isset.leader)
      {
        if(0 < tmp377++) { tmp376.Append(", "); }
        tmp376.Append("Leader: ");
        Leader.ToString(tmp376);
      }
      if((Parts != null) && __isset.parts)
      {
        if(0 < tmp377++) { tmp376.Append(", "); }
        tmp376.Append("Parts: ");
        Parts.ToString(tmp376);
      }
      if((Terms != null) && __isset.terms)
      {
        if(0 < tmp377++) { tmp376.Append(", "); }
        tmp376.Append("Terms: ");
        Terms.ToString(tmp376);
      }
      tmp376.Append(')');
      return tmp376.ToString();
    }
  }

}
