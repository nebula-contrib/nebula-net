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

  public partial class DirInfo : TBase
  {
    private byte[] _root;
    private List<byte[]> _data;

    public byte[] Root
    {
      get
      {
        return _root;
      }
      set
      {
        __isset.root = true;
        this._root = value;
      }
    }

    public List<byte[]> Data
    {
      get
      {
        return _data;
      }
      set
      {
        __isset.data = true;
        this._data = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool root;
      public bool data;
    }

    public DirInfo()
    {
    }

    public DirInfo DeepCopy()
    {
      var tmp175 = new DirInfo();
      if((Root != null) && __isset.root)
      {
        tmp175.Root = this.Root.ToArray();
      }
      tmp175.__isset.root = this.__isset.root;
      if((Data != null) && __isset.data)
      {
        tmp175.Data = this.Data.DeepCopy();
      }
      tmp175.__isset.data = this.__isset.data;
      return tmp175;
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
              if (field.Type == TType.String)
              {
                Root = await iprot.ReadBinaryAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.List)
              {
                {
                  TList _list176 = await iprot.ReadListBeginAsync(cancellationToken);
                  Data = new List<byte[]>(_list176.Count);
                  for(int _i177 = 0; _i177 < _list176.Count; ++_i177)
                  {
                    byte[] _elem178;
                    _elem178 = await iprot.ReadBinaryAsync(cancellationToken);
                    Data.Add(_elem178);
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
        var tmp179 = new TStruct("DirInfo");
        await oprot.WriteStructBeginAsync(tmp179, cancellationToken);
        var tmp180 = new TField();
        if((Root != null) && __isset.root)
        {
          tmp180.Name = "root";
          tmp180.Type = TType.String;
          tmp180.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp180, cancellationToken);
          await oprot.WriteBinaryAsync(Root, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Data != null) && __isset.data)
        {
          tmp180.Name = "data";
          tmp180.Type = TType.List;
          tmp180.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp180, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.String, Data.Count), cancellationToken);
            foreach (byte[] _iter181 in Data)
            {
              await oprot.WriteBinaryAsync(_iter181, cancellationToken);
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
      if (!(that is DirInfo other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.root == other.__isset.root) && ((!__isset.root) || (TCollections.Equals(Root, other.Root))))
        && ((__isset.data == other.__isset.data) && ((!__isset.data) || (TCollections.Equals(Data, other.Data))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Root != null) && __isset.root)
        {
          hashcode = (hashcode * 397) + Root.GetHashCode();
        }
        if((Data != null) && __isset.data)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Data);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp182 = new StringBuilder("DirInfo(");
      int tmp183 = 0;
      if((Root != null) && __isset.root)
      {
        if(0 < tmp183++) { tmp182.Append(", "); }
        tmp182.Append("Root: ");
        Root.ToString(tmp182);
      }
      if((Data != null) && __isset.data)
      {
        if(0 < tmp183++) { tmp182.Append(", "); }
        tmp182.Append("Data: ");
        Data.ToString(tmp182);
      }
      tmp182.Append(')');
      return tmp182.ToString();
    }
  }

}
