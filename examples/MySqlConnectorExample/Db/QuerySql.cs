using System;

public byte[]? cBit { get; set; }
public int? cTinyint { get; set; }
public int? cBool { get; set; }
public int? cBoolean { get; set; }
public int? cSmallint { get; set; }
public int? cMediumint { get; set; }
public int? cInt { get; set; }
public int? cInteger { get; set; }
public long? cBigint { get; set; }
public long cSerial { get; set; }
public string cDecimal { get; set; }
public string cDec { get; set; }
public string cNumeric { get; set; }
public string cFixed { get; set; }
public double? cFloat { get; set; }
public double? cDouble { get; set; }
public double? cDoublePrecision { get; set; }
public string cDate { get; set; }
public string cTime { get; set; }
public string cDatetime { get; set; }
public string cTimestamp { get; set; }
public int? cYear { get; set; }
public string cChar { get; set; }
public string cNchar { get; set; }
public string cNationalChar { get; set; }
public string cVarchar { get; set; }
public byte[]? cBinary { get; set; }
public byte[]? cVarbinary { get; set; }
public byte[]? cTinyblob { get; set; }
public string cTinytext { get; set; }
public byte[]? cBlob { get; set; }
public string cText { get; set; }
public byte[]? cMediumblob { get; set; }
public string cMediumtext { get; set; }
public byte[]? cLongblob { get; set; }
public string cLongtext { get; set; }
public object? cJson { get; set; }publicasyncTask<TestRow?>Test(Clientclient){return// Placeholder for actual database query executionTask.FromResult(// Convert row to ReturnType instanceConvertToReturnType(row));}