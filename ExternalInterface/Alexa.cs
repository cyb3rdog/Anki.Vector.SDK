// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: anki_vector/messaging/alexa.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Anki.Vector.ExternalInterface {

  /// <summary>Holder for reflection information generated from anki_vector/messaging/alexa.proto</summary>
  public static partial class AlexaReflection {

    #region Descriptor
    /// <summary>File descriptor for anki_vector/messaging/alexa.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AlexaReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiFhbmtpX3ZlY3Rvci9tZXNzYWdpbmcvYWxleGEucHJvdG8SHkFua2kuVmVj",
            "dG9yLmV4dGVybmFsX2ludGVyZmFjZRorYW5raV92ZWN0b3IvbWVzc2FnaW5n",
            "L3Jlc3BvbnNlX3N0YXR1cy5wcm90byIXChVBbGV4YUF1dGhTdGF0ZVJlcXVl",
            "c3QiqwEKFkFsZXhhQXV0aFN0YXRlUmVzcG9uc2USPgoGc3RhdHVzGAEgASgL",
            "Mi4uQW5raS5WZWN0b3IuZXh0ZXJuYWxfaW50ZXJmYWNlLlJlc3BvbnNlU3Rh",
            "dHVzEkIKCmF1dGhfc3RhdGUYAiABKA4yLi5BbmtpLlZlY3Rvci5leHRlcm5h",
            "bF9pbnRlcmZhY2UuQWxleGFBdXRoU3RhdGUSDQoFZXh0cmEYAyABKAkiIwoR",
            "QWxleGFPcHRJblJlcXVlc3QSDgoGb3B0X2luGAEgASgIIlQKEkFsZXhhT3B0",
            "SW5SZXNwb25zZRI+CgZzdGF0dXMYASABKAsyLi5BbmtpLlZlY3Rvci5leHRl",
            "cm5hbF9pbnRlcmZhY2UuUmVzcG9uc2VTdGF0dXMiYwoOQWxleGFBdXRoRXZl",
            "bnQSQgoKYXV0aF9zdGF0ZRgBIAEoDjIuLkFua2kuVmVjdG9yLmV4dGVybmFs",
            "X2ludGVyZmFjZS5BbGV4YUF1dGhTdGF0ZRINCgVleHRyYRgCIAEoCSqiAQoO",
            "QWxleGFBdXRoU3RhdGUSFgoSQUxFWEFfQVVUSF9JTlZBTElEEAASHAoYQUxF",
            "WEFfQVVUSF9VTklOSVRJQUxJWkVEEAESHgoaQUxFWEFfQVVUSF9SRVFVRVNU",
            "SU5HX0FVVEgQAhIfChtBTEVYQV9BVVRIX1dBSVRJTkdfRk9SX0NPREUQAxIZ",
            "ChVBTEVYQV9BVVRIX0FVVEhPUklaRUQQBEI6WjhnaXRodWIuY29tL2RpZ2l0",
            "YWwtZHJlYW0tbGFicy92ZWN0b3ItZ28tc2RrL3BrZy92ZWN0b3JwYmIGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Anki.Vector.ExternalInterface.ResponseStatusReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Anki.Vector.ExternalInterface.AlexaAuthState), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Anki.Vector.ExternalInterface.AlexaAuthStateRequest), global::Anki.Vector.ExternalInterface.AlexaAuthStateRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anki.Vector.ExternalInterface.AlexaAuthStateResponse), global::Anki.Vector.ExternalInterface.AlexaAuthStateResponse.Parser, new[]{ "Status", "AuthState", "Extra" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anki.Vector.ExternalInterface.AlexaOptInRequest), global::Anki.Vector.ExternalInterface.AlexaOptInRequest.Parser, new[]{ "OptIn" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anki.Vector.ExternalInterface.AlexaOptInResponse), global::Anki.Vector.ExternalInterface.AlexaOptInResponse.Parser, new[]{ "Status" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anki.Vector.ExternalInterface.AlexaAuthEvent), global::Anki.Vector.ExternalInterface.AlexaAuthEvent.Parser, new[]{ "AuthState", "Extra" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum AlexaAuthState {
    /// <summary>
    /// Invalid/error/versioning issue
    /// </summary>
    [pbr::OriginalName("ALEXA_AUTH_INVALID")] AlexaAuthInvalid = 0,
    /// <summary>
    /// Not opted in, or opt-in attempted but failed
    /// </summary>
    [pbr::OriginalName("ALEXA_AUTH_UNINITIALIZED")] AlexaAuthUninitialized = 1,
    /// <summary>
    /// Opted in, and attempting to authorize
    /// </summary>
    [pbr::OriginalName("ALEXA_AUTH_REQUESTING_AUTH")] AlexaAuthRequestingAuth = 2,
    /// <summary>
    /// Opted in, and waiting on the user to enter a code
    /// </summary>
    [pbr::OriginalName("ALEXA_AUTH_WAITING_FOR_CODE")] AlexaAuthWaitingForCode = 3,
    /// <summary>
    /// Opted in, and authorized / in use
    /// </summary>
    [pbr::OriginalName("ALEXA_AUTH_AUTHORIZED")] AlexaAuthAuthorized = 4,
  }

  #endregion

  #region Messages
  public sealed partial class AlexaAuthStateRequest : pb::IMessage<AlexaAuthStateRequest> {
    private static readonly pb::MessageParser<AlexaAuthStateRequest> _parser = new pb::MessageParser<AlexaAuthStateRequest>(() => new AlexaAuthStateRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AlexaAuthStateRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anki.Vector.ExternalInterface.AlexaReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateRequest(AlexaAuthStateRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateRequest Clone() {
      return new AlexaAuthStateRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AlexaAuthStateRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AlexaAuthStateRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AlexaAuthStateRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class AlexaAuthStateResponse : pb::IMessage<AlexaAuthStateResponse> {
    private static readonly pb::MessageParser<AlexaAuthStateResponse> _parser = new pb::MessageParser<AlexaAuthStateResponse>(() => new AlexaAuthStateResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AlexaAuthStateResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anki.Vector.ExternalInterface.AlexaReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateResponse(AlexaAuthStateResponse other) : this() {
      status_ = other.status_ != null ? other.status_.Clone() : null;
      authState_ = other.authState_;
      extra_ = other.extra_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthStateResponse Clone() {
      return new AlexaAuthStateResponse(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private global::Anki.Vector.ExternalInterface.ResponseStatus status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Anki.Vector.ExternalInterface.ResponseStatus Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "auth_state" field.</summary>
    public const int AuthStateFieldNumber = 2;
    private global::Anki.Vector.ExternalInterface.AlexaAuthState authState_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Anki.Vector.ExternalInterface.AlexaAuthState AuthState {
      get { return authState_; }
      set {
        authState_ = value;
      }
    }

    /// <summary>Field number for the "extra" field.</summary>
    public const int ExtraFieldNumber = 3;
    private string extra_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Extra {
      get { return extra_; }
      set {
        extra_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AlexaAuthStateResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AlexaAuthStateResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Status, other.Status)) return false;
      if (AuthState != other.AuthState) return false;
      if (Extra != other.Extra) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (status_ != null) hash ^= Status.GetHashCode();
      if (AuthState != 0) hash ^= AuthState.GetHashCode();
      if (Extra.Length != 0) hash ^= Extra.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (status_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Status);
      }
      if (AuthState != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) AuthState);
      }
      if (Extra.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Extra);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (status_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Status);
      }
      if (AuthState != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) AuthState);
      }
      if (Extra.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Extra);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AlexaAuthStateResponse other) {
      if (other == null) {
        return;
      }
      if (other.status_ != null) {
        if (status_ == null) {
          status_ = new global::Anki.Vector.ExternalInterface.ResponseStatus();
        }
        Status.MergeFrom(other.Status);
      }
      if (other.AuthState != 0) {
        AuthState = other.AuthState;
      }
      if (other.Extra.Length != 0) {
        Extra = other.Extra;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (status_ == null) {
              status_ = new global::Anki.Vector.ExternalInterface.ResponseStatus();
            }
            input.ReadMessage(status_);
            break;
          }
          case 16: {
            authState_ = (global::Anki.Vector.ExternalInterface.AlexaAuthState) input.ReadEnum();
            break;
          }
          case 26: {
            Extra = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AlexaOptInRequest : pb::IMessage<AlexaOptInRequest> {
    private static readonly pb::MessageParser<AlexaOptInRequest> _parser = new pb::MessageParser<AlexaOptInRequest>(() => new AlexaOptInRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AlexaOptInRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anki.Vector.ExternalInterface.AlexaReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInRequest(AlexaOptInRequest other) : this() {
      optIn_ = other.optIn_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInRequest Clone() {
      return new AlexaOptInRequest(this);
    }

    /// <summary>Field number for the "opt_in" field.</summary>
    public const int OptInFieldNumber = 1;
    private bool optIn_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool OptIn {
      get { return optIn_; }
      set {
        optIn_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AlexaOptInRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AlexaOptInRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OptIn != other.OptIn) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OptIn != false) hash ^= OptIn.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OptIn != false) {
        output.WriteRawTag(8);
        output.WriteBool(OptIn);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OptIn != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AlexaOptInRequest other) {
      if (other == null) {
        return;
      }
      if (other.OptIn != false) {
        OptIn = other.OptIn;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            OptIn = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AlexaOptInResponse : pb::IMessage<AlexaOptInResponse> {
    private static readonly pb::MessageParser<AlexaOptInResponse> _parser = new pb::MessageParser<AlexaOptInResponse>(() => new AlexaOptInResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AlexaOptInResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anki.Vector.ExternalInterface.AlexaReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInResponse(AlexaOptInResponse other) : this() {
      status_ = other.status_ != null ? other.status_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaOptInResponse Clone() {
      return new AlexaOptInResponse(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private global::Anki.Vector.ExternalInterface.ResponseStatus status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Anki.Vector.ExternalInterface.ResponseStatus Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AlexaOptInResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AlexaOptInResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Status, other.Status)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (status_ != null) hash ^= Status.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (status_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Status);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (status_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Status);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AlexaOptInResponse other) {
      if (other == null) {
        return;
      }
      if (other.status_ != null) {
        if (status_ == null) {
          status_ = new global::Anki.Vector.ExternalInterface.ResponseStatus();
        }
        Status.MergeFrom(other.Status);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (status_ == null) {
              status_ = new global::Anki.Vector.ExternalInterface.ResponseStatus();
            }
            input.ReadMessage(status_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class AlexaAuthEvent : pb::IMessage<AlexaAuthEvent> {
    private static readonly pb::MessageParser<AlexaAuthEvent> _parser = new pb::MessageParser<AlexaAuthEvent>(() => new AlexaAuthEvent());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AlexaAuthEvent> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anki.Vector.ExternalInterface.AlexaReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthEvent() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthEvent(AlexaAuthEvent other) : this() {
      authState_ = other.authState_;
      extra_ = other.extra_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AlexaAuthEvent Clone() {
      return new AlexaAuthEvent(this);
    }

    /// <summary>Field number for the "auth_state" field.</summary>
    public const int AuthStateFieldNumber = 1;
    private global::Anki.Vector.ExternalInterface.AlexaAuthState authState_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Anki.Vector.ExternalInterface.AlexaAuthState AuthState {
      get { return authState_; }
      set {
        authState_ = value;
      }
    }

    /// <summary>Field number for the "extra" field.</summary>
    public const int ExtraFieldNumber = 2;
    private string extra_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Extra {
      get { return extra_; }
      set {
        extra_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AlexaAuthEvent);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AlexaAuthEvent other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AuthState != other.AuthState) return false;
      if (Extra != other.Extra) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AuthState != 0) hash ^= AuthState.GetHashCode();
      if (Extra.Length != 0) hash ^= Extra.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AuthState != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) AuthState);
      }
      if (Extra.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Extra);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AuthState != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) AuthState);
      }
      if (Extra.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Extra);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AlexaAuthEvent other) {
      if (other == null) {
        return;
      }
      if (other.AuthState != 0) {
        AuthState = other.AuthState;
      }
      if (other.Extra.Length != 0) {
        Extra = other.Extra;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            authState_ = (global::Anki.Vector.ExternalInterface.AlexaAuthState) input.ReadEnum();
            break;
          }
          case 18: {
            Extra = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
