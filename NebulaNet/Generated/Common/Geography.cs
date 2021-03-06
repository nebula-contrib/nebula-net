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

namespace Nebula.Common
{

  public partial class Geography : TBase
  {
    private global::Nebula.Common.Point _ptVal;
    private global::Nebula.Common.LineString _lsVal;
    private global::Nebula.Common.Polygon _pgVal;

    public global::Nebula.Common.Point PtVal
    {
      get
      {
        return _ptVal;
      }
      set
      {
        __isset.ptVal = true;
        this._ptVal = value;
      }
    }

    public global::Nebula.Common.LineString LsVal
    {
      get
      {
        return _lsVal;
      }
      set
      {
        __isset.lsVal = true;
        this._lsVal = value;
      }
    }

    public global::Nebula.Common.Polygon PgVal
    {
      get
      {
        return _pgVal;
      }
      set
      {
        __isset.pgVal = true;
        this._pgVal = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool ptVal;
      public bool lsVal;
      public bool pgVal;
    }

    public Geography()
    {
    }

    public Geography DeepCopy()
    {
      var tmp107 = new Geography();
      if((PtVal != null) && __isset.ptVal)
      {
        tmp107.PtVal = (global::Nebula.Common.Point)this.PtVal.DeepCopy();
      }
      tmp107.__isset.ptVal = this.__isset.ptVal;
      if((LsVal != null) && __isset.lsVal)
      {
        tmp107.LsVal = (global::Nebula.Common.LineString)this.LsVal.DeepCopy();
      }
      tmp107.__isset.lsVal = this.__isset.lsVal;
      if((PgVal != null) && __isset.pgVal)
      {
        tmp107.PgVal = (global::Nebula.Common.Polygon)this.PgVal.DeepCopy();
      }
      tmp107.__isset.pgVal = this.__isset.pgVal;
      return tmp107;
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
                PtVal = new global::Nebula.Common.Point();
                await PtVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                LsVal = new global::Nebula.Common.LineString();
                await LsVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                PgVal = new global::Nebula.Common.Polygon();
                await PgVal.ReadAsync(iprot, cancellationToken);
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
        var tmp108 = new TStruct("Geography");
        await oprot.WriteStructBeginAsync(tmp108, cancellationToken);
        var tmp109 = new TField();
        if((PtVal != null) && __isset.ptVal)
        {
          tmp109.Name = "ptVal";
          tmp109.Type = TType.Struct;
          tmp109.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp109, cancellationToken);
          await PtVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((LsVal != null) && __isset.lsVal)
        {
          tmp109.Name = "lsVal";
          tmp109.Type = TType.Struct;
          tmp109.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp109, cancellationToken);
          await LsVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((PgVal != null) && __isset.pgVal)
        {
          tmp109.Name = "pgVal";
          tmp109.Type = TType.Struct;
          tmp109.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp109, cancellationToken);
          await PgVal.WriteAsync(oprot, cancellationToken);
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
      if (!(that is Geography other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.ptVal == other.__isset.ptVal) && ((!__isset.ptVal) || (System.Object.Equals(PtVal, other.PtVal))))
        && ((__isset.lsVal == other.__isset.lsVal) && ((!__isset.lsVal) || (System.Object.Equals(LsVal, other.LsVal))))
        && ((__isset.pgVal == other.__isset.pgVal) && ((!__isset.pgVal) || (System.Object.Equals(PgVal, other.PgVal))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((PtVal != null) && __isset.ptVal)
        {
          hashcode = (hashcode * 397) + PtVal.GetHashCode();
        }
        if((LsVal != null) && __isset.lsVal)
        {
          hashcode = (hashcode * 397) + LsVal.GetHashCode();
        }
        if((PgVal != null) && __isset.pgVal)
        {
          hashcode = (hashcode * 397) + PgVal.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp110 = new StringBuilder("Geography(");
      int tmp111 = 0;
      if((PtVal != null) && __isset.ptVal)
      {
        if(0 < tmp111++) { tmp110.Append(", "); }
        tmp110.Append("PtVal: ");
        PtVal.ToString(tmp110);
      }
      if((LsVal != null) && __isset.lsVal)
      {
        if(0 < tmp111++) { tmp110.Append(", "); }
        tmp110.Append("LsVal: ");
        LsVal.ToString(tmp110);
      }
      if((PgVal != null) && __isset.pgVal)
      {
        if(0 < tmp111++) { tmp110.Append(", "); }
        tmp110.Append("PgVal: ");
        PgVal.ToString(tmp110);
      }
      tmp110.Append(')');
      return tmp110.ToString();
    }
  }

}
