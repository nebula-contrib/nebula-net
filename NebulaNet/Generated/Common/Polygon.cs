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

  public partial class Polygon : TBase
  {
    private List<List<global::Nebula.Common.Coordinate>> _coordListList;

    public List<List<global::Nebula.Common.Coordinate>> CoordListList
    {
      get
      {
        return _coordListList;
      }
      set
      {
        __isset.coordListList = true;
        this._coordListList = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool coordListList;
    }

    public Polygon()
    {
    }

    public Polygon DeepCopy()
    {
      var tmp94 = new Polygon();
      if((CoordListList != null) && __isset.coordListList)
      {
        tmp94.CoordListList = this.CoordListList.DeepCopy();
      }
      tmp94.__isset.coordListList = this.__isset.coordListList;
      return tmp94;
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
              if (field.Type == TType.List)
              {
                {
                  TList _list95 = await iprot.ReadListBeginAsync(cancellationToken);
                  CoordListList = new List<List<global::Nebula.Common.Coordinate>>(_list95.Count);
                  for(int _i96 = 0; _i96 < _list95.Count; ++_i96)
                  {
                    List<global::Nebula.Common.Coordinate> _elem97;
                    {
                      TList _list98 = await iprot.ReadListBeginAsync(cancellationToken);
                      _elem97 = new List<global::Nebula.Common.Coordinate>(_list98.Count);
                      for(int _i99 = 0; _i99 < _list98.Count; ++_i99)
                      {
                        global::Nebula.Common.Coordinate _elem100;
                        _elem100 = new global::Nebula.Common.Coordinate();
                        await _elem100.ReadAsync(iprot, cancellationToken);
                        _elem97.Add(_elem100);
                      }
                      await iprot.ReadListEndAsync(cancellationToken);
                    }
                    CoordListList.Add(_elem97);
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
        var tmp101 = new TStruct("Polygon");
        await oprot.WriteStructBeginAsync(tmp101, cancellationToken);
        var tmp102 = new TField();
        if((CoordListList != null) && __isset.coordListList)
        {
          tmp102.Name = "coordListList";
          tmp102.Type = TType.List;
          tmp102.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp102, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.List, CoordListList.Count), cancellationToken);
            foreach (List<global::Nebula.Common.Coordinate> _iter103 in CoordListList)
            {
              {
                await oprot.WriteListBeginAsync(new TList(TType.Struct, _iter103.Count), cancellationToken);
                foreach (global::Nebula.Common.Coordinate _iter104 in _iter103)
                {
                  await _iter104.WriteAsync(oprot, cancellationToken);
                }
                await oprot.WriteListEndAsync(cancellationToken);
              }
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
      if (!(that is Polygon other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.coordListList == other.__isset.coordListList) && ((!__isset.coordListList) || (TCollections.Equals(CoordListList, other.CoordListList))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((CoordListList != null) && __isset.coordListList)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(CoordListList);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp105 = new StringBuilder("Polygon(");
      int tmp106 = 0;
      if((CoordListList != null) && __isset.coordListList)
      {
        if(0 < tmp106++) { tmp105.Append(", "); }
        tmp105.Append("CoordListList: ");
        CoordListList.ToString(tmp105);
      }
      tmp105.Append(')');
      return tmp105.ToString();
    }
  }

}
