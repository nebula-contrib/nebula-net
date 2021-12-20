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

  public partial class EdgeKey : TBase
  {
    private global::Nebula.Common.@Value _src;
    private int _edge_type;
    private long _ranking;
    private global::Nebula.Common.@Value _dst;

    public global::Nebula.Common.@Value Src
    {
      get
      {
        return _src;
      }
      set
      {
        __isset.src = true;
        this._src = value;
      }
    }

    public int Edge_type
    {
      get
      {
        return _edge_type;
      }
      set
      {
        __isset.edge_type = true;
        this._edge_type = value;
      }
    }

    public long Ranking
    {
      get
      {
        return _ranking;
      }
      set
      {
        __isset.ranking = true;
        this._ranking = value;
      }
    }

    public global::Nebula.Common.@Value Dst
    {
      get
      {
        return _dst;
      }
      set
      {
        __isset.dst = true;
        this._dst = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool src;
      public bool edge_type;
      public bool ranking;
      public bool dst;
    }

    public EdgeKey()
    {
    }

    public EdgeKey DeepCopy()
    {
      var tmp167 = new EdgeKey();
      if((Src != null) && __isset.src)
      {
        tmp167.Src = (global::Nebula.Common.@Value)this.Src.DeepCopy();
      }
      tmp167.__isset.src = this.__isset.src;
      if(__isset.edge_type)
      {
        tmp167.Edge_type = this.Edge_type;
      }
      tmp167.__isset.edge_type = this.__isset.edge_type;
      if(__isset.ranking)
      {
        tmp167.Ranking = this.Ranking;
      }
      tmp167.__isset.ranking = this.__isset.ranking;
      if((Dst != null) && __isset.dst)
      {
        tmp167.Dst = (global::Nebula.Common.@Value)this.Dst.DeepCopy();
      }
      tmp167.__isset.dst = this.__isset.dst;
      return tmp167;
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
                Src = new global::Nebula.Common.@Value();
                await Src.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I32)
              {
                Edge_type = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I64)
              {
                Ranking = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.Struct)
              {
                Dst = new global::Nebula.Common.@Value();
                await Dst.ReadAsync(iprot, cancellationToken);
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
        var tmp168 = new TStruct("EdgeKey");
        await oprot.WriteStructBeginAsync(tmp168, cancellationToken);
        var tmp169 = new TField();
        if((Src != null) && __isset.src)
        {
          tmp169.Name = "src";
          tmp169.Type = TType.Struct;
          tmp169.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp169, cancellationToken);
          await Src.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.edge_type)
        {
          tmp169.Name = "edge_type";
          tmp169.Type = TType.I32;
          tmp169.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp169, cancellationToken);
          await oprot.WriteI32Async(Edge_type, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.ranking)
        {
          tmp169.Name = "ranking";
          tmp169.Type = TType.I64;
          tmp169.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp169, cancellationToken);
          await oprot.WriteI64Async(Ranking, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Dst != null) && __isset.dst)
        {
          tmp169.Name = "dst";
          tmp169.Type = TType.Struct;
          tmp169.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp169, cancellationToken);
          await Dst.WriteAsync(oprot, cancellationToken);
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
      if (!(that is EdgeKey other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.src == other.__isset.src) && ((!__isset.src) || (System.Object.Equals(Src, other.Src))))
        && ((__isset.edge_type == other.__isset.edge_type) && ((!__isset.edge_type) || (System.Object.Equals(Edge_type, other.Edge_type))))
        && ((__isset.ranking == other.__isset.ranking) && ((!__isset.ranking) || (System.Object.Equals(Ranking, other.Ranking))))
        && ((__isset.dst == other.__isset.dst) && ((!__isset.dst) || (System.Object.Equals(Dst, other.Dst))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Src != null) && __isset.src)
        {
          hashcode = (hashcode * 397) + Src.GetHashCode();
        }
        if(__isset.edge_type)
        {
          hashcode = (hashcode * 397) + Edge_type.GetHashCode();
        }
        if(__isset.ranking)
        {
          hashcode = (hashcode * 397) + Ranking.GetHashCode();
        }
        if((Dst != null) && __isset.dst)
        {
          hashcode = (hashcode * 397) + Dst.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp170 = new StringBuilder("EdgeKey(");
      int tmp171 = 0;
      if((Src != null) && __isset.src)
      {
        if(0 < tmp171++) { tmp170.Append(", "); }
        tmp170.Append("Src: ");
        Src.ToString(tmp170);
      }
      if(__isset.edge_type)
      {
        if(0 < tmp171++) { tmp170.Append(", "); }
        tmp170.Append("Edge_type: ");
        Edge_type.ToString(tmp170);
      }
      if(__isset.ranking)
      {
        if(0 < tmp171++) { tmp170.Append(", "); }
        tmp170.Append("Ranking: ");
        Ranking.ToString(tmp170);
      }
      if((Dst != null) && __isset.dst)
      {
        if(0 < tmp171++) { tmp170.Append(", "); }
        tmp170.Append("Dst: ");
        Dst.ToString(tmp170);
      }
      tmp170.Append(')');
      return tmp170.ToString();
    }
  }

}
