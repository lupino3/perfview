using Microsoft.Diagnostics.Utilities;
using System;
using System.Diagnostics;
using System.Text;

// This code was automatically generated by the TraceParserGen tool, which converts
// an ETW event manifest into strongly typed C# classes.
namespace Microsoft.Diagnostics.Tracing.Parsers
{
    using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsNDISPacketCapture;

    [System.CodeDom.Compiler.GeneratedCode("traceparsergen", "2.0")]
    public sealed class MicrosoftWindowsNDISPacketCaptureTraceEventParser : TraceEventParser
    {
        public static string ProviderName = "Microsoft-Windows-NDIS-PacketCapture";
        public static Guid ProviderGuid = new Guid(unchecked((int)0x2ed6006e), unchecked((short)0x4729), unchecked((short)0x4609), 0xb4, 0x23, 0x3e, 0xe7, 0xbc, 0xd6, 0x78, 0xef);
        public enum Keywords : long
        {
            Ethernet8023 = 0x1,
            Wirelesswan = 0x200,
            Tunnel = 0x8000,
            StringkeywordNative80211 = 0x10000,
            Vmswitch = 0x1000000,
            Packettruncated = 0x2000000,
            Packetstart = 0x40000000,
            Packetend = 0x80000000,
            Utsendpath = 0x100000000,
            Utreceivepath = 0x200000000,
            Utl3connectpath = 0x400000000,
            Utl2connectpath = 0x800000000,
            Utclosepath = 0x1000000000,
            Utauthentication = 0x2000000000,
            Utconfiguration = 0x4000000000,
            Utglobal = 0x8000000000,
        };

        public MicrosoftWindowsNDISPacketCaptureTraceEventParser(TraceEventSource source) : base(source) { }

        public event Action<PacketFragmentArgs> PacketFragment
        {
            add
            {
                source.RegisterEventTemplate(PacketFragmentTemplate(value, State));
            }
            remove
            {
                source.UnregisterEventTemplate(value, 1001, ProviderGuid);
            }
        }
        public event Action<PacketMetaDataArgs> PacketMetaData
        {
            add
            {
                source.RegisterEventTemplate(PacketMetaDataTemplate(value, State));
            }
            remove
            {
                source.UnregisterEventTemplate(value, 1002, ProviderGuid);
            }
        }

        #region private
        protected override string GetProviderName() { return ProviderName; }

        static private PacketFragmentArgs PacketFragmentTemplate(Action<PacketFragmentArgs> action, MicrosoftWindowsNDISPacketCaptureTraceEventParserState state)
        {                  // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
            // TODO FIX NOW HACK
            return new PacketFragmentArgs(action, 1001, 0, "PacketFragment", Guid.Empty, 0, "", ProviderGuid, ProviderName, state);
        }
        static private PacketMetaDataArgs PacketMetaDataTemplate(Action<PacketMetaDataArgs> action, MicrosoftWindowsNDISPacketCaptureTraceEventParserState state)
        {                  // action, eventid, taskid, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName
            // TODO FIX NOW HACK
            return new PacketMetaDataArgs(action, 1002, 0, "PacketMetaData", Guid.Empty, 0, "", ProviderGuid, ProviderName, state);
        }

        static private volatile TraceEvent[] s_templates;
        protected internal override void EnumerateTemplates(Func<string, string, EventFilterResponse> eventsToObserve, Action<TraceEvent> callback)
        {
            if (s_templates == null)
            {
                var templates = new TraceEvent[2];
                templates[0] = PacketFragmentTemplate(null, null);
                templates[1] = PacketMetaDataTemplate(null, null);
                s_templates = templates;
            }
            foreach (var template in s_templates)
                if (eventsToObserve == null || eventsToObserve(template.ProviderName, template.EventName) == EventFilterResponse.AcceptEvent)
                    callback(template);
        }

        MicrosoftWindowsNDISPacketCaptureTraceEventParserState State
        {
            get
            {
                MicrosoftWindowsNDISPacketCaptureTraceEventParserState ret = (MicrosoftWindowsNDISPacketCaptureTraceEventParserState)StateObject;
                if (ret == null)
                {
                    ret = new MicrosoftWindowsNDISPacketCaptureTraceEventParserState();
                    StateObject = ret;
                }
                return ret;
            }
        }
        #endregion
    }

    #region internal classes 
    internal unsafe class MicrosoftWindowsNDISPacketCaptureTraceEventParserState
    {

        public MicrosoftWindowsNDISPacketCaptureTraceEventParserState()
        {
            m_FragmentEventIndex = EventIndex.Invalid;
        }

        internal Guid m_FragmentActivity;
        internal EventIndex m_FragmentEventIndex;
        internal bool m_TCPHeaderInPreviousFragment;
        internal byte* m_TCPHeader;
        internal byte* m_TCPHeaderEnd;
        internal int m_TCPHeaderMax;

        ~MicrosoftWindowsNDISPacketCaptureTraceEventParserState()
        {
            if (m_TCPHeader != null)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)m_TCPHeader);
                m_TCPHeader = null;
            }
        }
    }
    #endregion

}

namespace Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsNDISPacketCapture
{
    public sealed class PacketFragmentArgs : TraceEvent
    {
        public int MiniportIfIndex { get { return GetInt32At(0); } }
        public int LowerIfIndex { get { return GetInt32At(4); } }
        public int FragmentSize { get { return GetInt32At(8); } }
        public unsafe byte* Fragment { get { return (byte*)DataStart + 12; } }

        public string ParsedPacket
        {
            get
            {
                if (!parsed)
                {
                    ParsePacket();
                }
                return parsedPacket;
            }
        }

        public IPHeader IPHeader
        {
            get
            {
                if (!parsed)
                {
                    ParsePacket();
                }
                return ipHeader;
            }
        }

        public TCPHeader TCPHeader
        {
            get
            {
                if (!parsed)
                {
                    ParsePacket();
                }
                return tcpHeader;
            }
        }

        public UDPHeader UDPHeader
        {
            get
            {
                if (!parsed)
                {
                    ParsePacket();
                }
                return udpHeader;
            }
        }

        private unsafe void ParsePacket() {
            byte* frag = Fragment;
            byte* fragEnd = frag + FragmentSize;

            // TODO FIX NOW This is probably a hack
            if (m_state == null)
            {
                m_state = new MicrosoftWindowsNDISPacketCaptureTraceEventParserState();
            }

            bool TCPHeaderInPreviousFragment = m_state.m_TCPHeaderInPreviousFragment;
            m_state.m_TCPHeaderInPreviousFragment = false;

            // If we have a remembered header, use that.   
            byte* packetStart = null;
            bool isContinuationFragment = false;
            if (m_state.m_FragmentEventIndex + 1 == EventIndex && m_state.m_FragmentActivity == ActivityID)
            {
                isContinuationFragment = true;
                if (TCPHeaderInPreviousFragment)
                {
                    packetStart = m_state.m_TCPHeader;
                    fragEnd = m_state.m_TCPHeaderEnd;
                }
            }

            m_state.m_FragmentActivity = ActivityID;
            m_state.m_FragmentEventIndex = EventIndex;
            if (packetStart == null)
            {
                packetStart = FindIPHeader(frag, fragEnd);
            }

            if (packetStart != null)
            {
                StringBuilder sb = new StringBuilder();
                if (isContinuationFragment)
                {
                    sb.Append("CONT ").Append(ActivityID.ToString().Substring(6, 2)).Append(" ");
                }

                ipHeader = new IPHeader(packetStart);
                sb.Append("IP");
                sb.Append(" Source=").Append(ipHeader.SourceAddress);
                sb.Append(" Dest=").Append(ipHeader.DestinationAddress);

                if (ipHeader.Protocol == 6)  // TCP-IP
                {
                    tcpHeader = new TCPHeader(packetStart + ipHeader.IPHeaderSize);
                    sb.Append(" TCP");

                    // Create a connection ID.  This is the source IP/port dest IP/port hashed 
                    int connetionIDHash = ipHeader.SourceAddress.GetHashCode() + ipHeader.DestinationAddress.GetHashCode() + tcpHeader.SourcePort + tcpHeader.DestPort;
                    int connectionID = (ushort)(((uint)connetionIDHash >> 16) + connetionIDHash);
                    // Suffix it with a > or < to indicate direction 
                    char suffix = tcpHeader.SourcePort >= tcpHeader.DestPort ? '>' : '<';
                    sb.Append(" ConnID=").Append(connectionID.ToString("x")).Append(suffix);

                    sb.Append(" SPort=").Append(tcpHeader.SourcePort);
                    sb.Append(" DPort=").Append(tcpHeader.DestPort);
                    if (tcpHeader.Cwr)
                    {
                        sb.Append(" CWR");
                    }

                    if (tcpHeader.Ece)
                    {
                        sb.Append(" ECE");
                    }

                    if (tcpHeader.Urg)
                    {
                        sb.Append(" URG");
                    }

                    if (tcpHeader.Ack)
                    {
                        sb.Append(" ACK");
                    }

                    if (tcpHeader.Psh)
                    {
                        sb.Append(" PSH");
                    }

                    if (tcpHeader.Rst)
                    {
                        sb.Append(" RST");
                    }

                    if (tcpHeader.Syn)
                    {
                        sb.Append(" SYN");
                    }

                    if (tcpHeader.Fin)
                    {
                        sb.Append(" FIN");
                    }

                    if (tcpHeader.AnyOptions)
                    {
                        var scale = tcpHeader.WindowScale;
                        if (0 <= scale)
                        {
                            sb.Append(" WindowScale=").Append(scale);
                        }

                        var maxSeg = tcpHeader.MaximumSegmentSize;
                        if (0 <= maxSeg)
                        {
                            sb.Append(" MaxSeg=").Append(maxSeg);
                        }

                        if (tcpHeader.SelectivAckAllowed)
                        {
                            sb.Append(" SelectiveAck");
                        }

                        sb.Append(" TcpHdrLen=").Append(tcpHeader.TCPHeaderSize);
                    }
                    sb.Append(" Ack=0x").Append(tcpHeader.AckNumber.ToString("x"));
                    sb.Append(" Seq=0x").Append(tcpHeader.SequenceNumber.ToString("x"));
                    sb.Append(" Window=").Append(tcpHeader.WindowSize);
                    sb.Append(" Len=").Append(ipHeader.Length - ipHeader.IPHeaderSize - tcpHeader.TCPHeaderSize);

                    if (tcpHeader.DestPort == 80 || tcpHeader.SourcePort == 80)        // HTTP
                    {
                        byte* httpBase = packetStart + ipHeader.IPHeaderSize + tcpHeader.TCPHeaderSize;
                        if (TCPHeaderInPreviousFragment)
                        {
                            httpBase = Fragment;
                            fragEnd = httpBase + FragmentSize;
                        }
                        else if (httpBase == fragEnd)
                        {
                            m_state.m_TCPHeaderInPreviousFragment = true;

                            // Copy the bytes.  
                            var headerSize = ipHeader.IPHeaderSize + tcpHeader.TCPHeaderSize;
                            if (m_state.m_TCPHeaderMax < headerSize)
                            {
                                if (m_state.m_TCPHeader != null)
                                {
                                    System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)m_state.m_TCPHeader);
                                }

                                m_state.m_TCPHeaderMax = headerSize + 16;
                                m_state.m_TCPHeader = (byte*)System.Runtime.InteropServices.Marshal.AllocHGlobal(m_state.m_TCPHeaderMax);
                            }
                            m_state.m_TCPHeaderEnd = m_state.m_TCPHeader + headerSize;
                            var ptr = packetStart;
                            for (int i = 0; i < headerSize; i++)
                            {
                                m_state.m_TCPHeader[i] = *ptr++;
                            }
                        }

                        sb.Append(" HTTP");
                        if (httpBase < fragEnd)
                        {
                            AppendPrintable(httpBase, fragEnd, sb, " Stream=", 16);
                        }
                    }
                }
                else
                {
                    sb.Append(" Len=").Append(ipHeader.Length - ipHeader.IPHeaderSize);
                    if (ipHeader.Protocol == 17)        // UDP
                    {
                        sb.Append(" UDP");

                        udpHeader = new UDPHeader(packetStart + ipHeader.IPHeaderSize);
                        sb.Append(" SPort=").Append(udpHeader.SourcePort);
                        sb.Append(" DPort=").Append(udpHeader.DestPort);
                        sb.Append(" Length=").Append(udpHeader.Length);
                        sb.Append(" Checksum=").Append(udpHeader.Checksum);
                    }
                    else
                    {
                        sb.Append("IP(").Append(ipHeader.Protocol.ToString()).Append(")");
                    }
                }
                parsedPacket = sb.ToString();
            }
            else if (isContinuationFragment)
            {
                parsedPacket = "CONTINUATION FRAGMENT " + ActivityID.ToString().Substring(6, 2) + " SIZE=" + FragmentSize;
            }
            else
            {
                parsedPacket = "NON-IP FRAGMENT " + ActivityID.ToString().Substring(6, 2) + " SIZE=" + FragmentSize;
            }

            parsed = true;
        }

        public unsafe string TcpStreamSample
        {
            get
            {
                string sample = FindPrintableTcpStream(Fragment, FragmentSize, 128, true);
                if (sample == null)
                {
                    return "";
                }

                return sample.Replace("\r\n", " ");
            }
        }

        #region Private
        /// <summary>
        /// Sees if up to 'max' bytes of frag-fragend is a printable string and if so prints it to 'sb' with 
        /// 'prefix' before it.  
        /// </summary>
        private static unsafe void AppendPrintable(byte* frag, byte* fragEnd, StringBuilder sb, string prefix, int max)
        {
            var limit = frag + max;
            if (limit < fragEnd)
            {
                fragEnd = limit;
            }

            if (!IsPrintable(frag, fragEnd))
            {
                return;
            }

            // Then print it 
            sb.Append(prefix);
            for (byte* ptr = frag; ptr < fragEnd; ptr++)
            {
                if ((byte)' ' <= *ptr)
                {
                    sb.Append((char)*ptr);
                }
                else
                {
                    sb.Append(' ');
                }
            }
            sb.Append("...");
        }

        private static unsafe bool IsPrintable(byte* frag, byte* fragEnd)
        {
            // is the complete string printable?
            for (byte* ptr = frag; ptr < fragEnd; ptr++)
            {
                if (!((byte)'\n' <= *ptr && *ptr < 128))
                {
                    return false;
                }
            }
            return true;
        }

        private static unsafe byte* FindIPHeader(byte* frag, byte* fragEnd)
        {
            fragEnd -= 30;          //   

            // Only search out at most 50 bytes.  
            if (&frag[50] < fragEnd)
            {
                fragEnd = &frag[50];
            }

            byte* bestSoFar = null;
            while (frag < fragEnd)
            {
                if (*frag == 0x45)
                {
                    // Compute the header checksum
                    uint checkSum = 0;
                    ushort* ptr = (ushort*)frag;
                    for (int i = 0; i < 10; i++)
                    {
                        checkSum += *ptr++;
                    }

                    checkSum = (ushort)checkSum + (checkSum >> 16);
                    if (checkSum == 0xFFFF)
                    {
                        return frag;
                    }

                    var ip = new IPHeader(frag);
                    if (ip.CheckSum == 0 && bestSoFar == null)
                    {
                        bestSoFar = frag;
                    }
                }
                frag++;
            }
            return bestSoFar;
        }

        internal PacketFragmentArgs(Action<PacketFragmentArgs> target, int eventID, int task, string taskName, Guid taskGuid, int opcode, string opcodeName, Guid providerGuid, string providerName, MicrosoftWindowsNDISPacketCaptureTraceEventParserState state)
            : base(eventID, task, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName)
        {
            m_target = target;
            m_state = state;
        }
        protected internal override void Dispatch()
        {
            m_target(this);
        }
        protected internal override void Validate()
        {
            Debug.Assert(!(Version == 0 && EventDataLength != FragmentSize + 12));
            Debug.Assert(!(Version > 0 && EventDataLength < FragmentSize + 12));
        }
        protected internal override Delegate Target
        {
            get { return m_target; }
            set { m_target = (Action<PacketFragmentArgs>)value; }
        }
        public override unsafe StringBuilder ToXml(StringBuilder sb)
        {
            Prefix(sb);
            XmlAttrib(sb, "MiniportIfIndex", MiniportIfIndex);
            XmlAttrib(sb, "LowerIfIndex", LowerIfIndex);
            XmlAttrib(sb, "FragmentSize", FragmentSize).AppendLine();
            XmlAttrib(sb, "ParsedPacket", ParsedPacket);
            string httpHeader = FindPrintableTcpStream(Fragment, FragmentSize, int.MaxValue);
            if (httpHeader != null)
            {
                sb.AppendLine(">");
                sb.AppendLine(" <Printable>");
                var printHttpHheader = "  " + httpHeader.Replace("\n", "\n  ");     // indent it.  
                sb.AppendLine(XmlUtilities.XmlEscape(printHttpHheader));
                sb.AppendLine(" </Printable>");
                sb.Append("</Event>");
            }
            else
            {
                sb.Append("/>");
            }

            return sb;
        }

        private unsafe string FindPrintableTcpStream(byte* fragment, int fragmentSize, int maxLength, bool oneLine = false)
        {
            if (fragmentSize < 16)
            {
                return null;
            }

            byte* fragmentEnd = fragment + fragmentSize;
            if (!IsPrintable(fragment, fragment + 16))
            {
                byte* ipStart = FindIPHeader(fragment, fragmentEnd);
                if (ipStart == null)
                {
                    return null;
                }

                IPHeader ip = new IPHeader(ipStart);
                if (ip.Protocol != 6)   // TCP
                {
                    return null;
                }

                TCPHeader tcp = new TCPHeader(ipStart + ip.IPHeaderSize);
                var streamStart = tcp.TCPHeaderSize + ip.IPHeaderSize + ipStart;

                if (fragmentEnd - streamStart < 16)
                {
                    return null;
                }

                if (!IsPrintable(streamStart, streamStart + 16))
                {
                    return null;
                }

                fragment = streamStart;
            }

            StringBuilder sb = new StringBuilder();
            if (maxLength < fragmentEnd - fragment)
            {
                fragmentEnd = fragment + maxLength;
            }

            // As this point the fragment points at printable characters.   Keep going until it becomes unprintable 
            while (fragment < fragmentEnd)
            {
                byte b = *fragment;
                if (!((byte)'\n' <= b && b < 128))
                {
                    break;
                }

                if (oneLine && (b == '\r' || b == '\n'))
                {
                    break;
                }

                sb.Append((char)b);
                fragment++;
            }

            return sb.ToString();
        }

        public override string[] PayloadNames
        {
            get
            {
                if (payloadNames == null)
                {
                    payloadNames = new string[] { "MiniportIfIndex", "LowerIfIndex", "FragmentSize", "ParsedPacket", "TcpStreamSample" };
                }

                return payloadNames;
            }
        }

        public override object PayloadValue(int index)
        {
            switch (index)
            {
                case 0:
                    return MiniportIfIndex;
                case 1:
                    return LowerIfIndex;
                case 2:
                    return FragmentSize;
                case 3:
                    return ParsedPacket;
                case 4:
                    return TcpStreamSample;
                default:
                    Debug.Assert(false, "Bad field index");
                    return null;
            }
        }

        private event Action<PacketFragmentArgs> m_target;

        protected override internal void SetState(object newState) { m_state = (MicrosoftWindowsNDISPacketCaptureTraceEventParserState)newState; }
        private MicrosoftWindowsNDISPacketCaptureTraceEventParserState m_state;

        private bool parsed = false;
        private string parsedPacket;
        private IPHeader ipHeader;
        private TCPHeader tcpHeader;
        private UDPHeader udpHeader;
        #endregion
    }

    public unsafe sealed class IPHeader
    {
        public IPHeader(byte* address) { this.Address = address; }

        public int IPHeaderSize { get { return (Address[0] & 0xF) * 4; } }
        public int Length { get { return (Address[2] << 8) + Address[3]; } }
        public System.Net.IPAddress SourceAddress { get { return new System.Net.IPAddress(*((uint*)&Address[12])); } }
        public System.Net.IPAddress DestinationAddress { get { return new System.Net.IPAddress(*((uint*)&Address[16])); } }
        public byte Protocol { get { return Address[9]; } }
        public int CheckSum { get { return (Address[10] << 8) + Address[11]; } }

        public byte* Address { get; }
    }

    public unsafe sealed class UDPHeader
    {
        public UDPHeader(byte* address) { this.Address = address; }

        public int SourcePort { get { return (Address[0] << 8) + Address[1]; } }
        public int DestPort { get { return (Address[2] << 8) + Address[3]; } }
        public int Length { get { return (Address[4] << 8) + Address[5]; } }
        public int Checksum { get { return (Address[6] << 8) + Address[7]; } }
        public int UDPHeaderSize { get { return 8; } }

        public byte* Address { get; }
    }

    public unsafe sealed class TCPHeader
    {
        public TCPHeader(byte* address) { this.Address = address; }

        public int SourcePort { get { return (Address[0] << 8) + Address[1]; } }
        public int DestPort { get { return (Address[2] << 8) + Address[3]; } }
        public int SequenceNumber { get { return (((((Address[4] << 8) + Address[5]) << 8) + Address[6]) << 8) + Address[7]; } }
        public int AckNumber { get { return (((((Address[8] << 8) + Address[9]) << 8) + Address[10]) << 8) + Address[11]; } }
        public int TCPHeaderSize { get { return (Address[12] >> 4) * 4; } }
        public bool Ns { get { return (Address[12] & 0x1) != 0; } }
        public bool Cwr { get { return (Address[13] & 0x80) != 0; } }
        public bool Ece { get { return (Address[13] & 0x40) != 0; } }
        public bool Urg { get { return (Address[13] & 0x20) != 0; } }
        public bool Ack { get { return (Address[13] & 0x10) != 0; } }
        public bool Psh { get { return (Address[13] & 0x8) != 0; } }
        public bool Rst { get { return (Address[13] & 0x4) != 0; } }
        public bool Syn { get { return (Address[13] & 0x2) != 0; } }
        public bool Fin { get { return (Address[13] & 0x1) != 0; } }
        public int WindowSize { get { return (Address[14] << 8) + Address[15]; } }
        public int CheckSum { get { return (Address[16] << 8) + Address[17]; } }
        public int UrgentPointer { get { return (Address[18] << 8) + Address[19]; } }
        // Returns -1 if not present;
        public int WindowScale { get { return GetOption(3); } }
        public bool SelectivAckAllowed { get { return GetOption(4) == 0; } }
        public int MaximumSegmentSize { get { return GetOption(2); } }
        public bool AnyOptions { get { return 20 < TCPHeaderSize; } }

        public byte* Address { get; }

        #region private 
        private int GetOption(int optionID)
        {
            byte* optionsEnd = Address + TCPHeaderSize;
            byte* optionPtr = Address + 20;
            while (optionPtr < optionsEnd)
            {
                if (*optionPtr == 0)
                {
                    break;
                }

                if (*optionPtr == 1)
                {
                    optionPtr++;
                }
                else
                {
                    var len = optionPtr[1];
                    if (len < 2 || 10 < len)        // protect against errors. 
                    {
                        break;
                    }

                    if (*optionPtr == optionID)
                    {
                        if (len == 2)
                        {
                            return 0;
                        }

                        if (len == 3)
                        {
                            return optionPtr[2];
                        }

                        if (len == 4)
                        {
                            return (optionPtr[2] << 8) + optionPtr[3];
                        }

                        break;
                    }
                    optionPtr += len;
                }
            }
            return -1;
        }
        #endregion
    }

    public sealed class PacketMetaDataArgs : TraceEvent
    {
        public int MiniportIfIndex { get { return GetInt32At(0); } }
        public int LowerIfIndex { get { return GetInt32At(4); } }
        public int MetadataSize { get { return GetInt32At(8); } }
        public unsafe byte* Metadata { get { return (byte*)DataStart + 12; } }

        #region Private
        internal PacketMetaDataArgs(Action<PacketMetaDataArgs> target, int eventID, int task, string taskName, Guid taskGuid, int opcode, string opcodeName, Guid providerGuid, string providerName, MicrosoftWindowsNDISPacketCaptureTraceEventParserState state)
            : base(eventID, task, taskName, taskGuid, opcode, opcodeName, providerGuid, providerName)
        {
            m_target = target;
            m_state = state;
        }
        protected override internal void Dispatch()
        {
            m_target(this);
        }
        protected override internal void Validate()
        {
            Debug.Assert(!(Version == 0 && EventDataLength != MetadataSize + 12));
            Debug.Assert(!(Version > 0 && EventDataLength < MetadataSize + 12));
        }
        protected override internal Delegate Target
        {
            get { return m_target; }
            set { m_target = (Action<PacketMetaDataArgs>)value; }
        }
        public override StringBuilder ToXml(StringBuilder sb)
        {
            Prefix(sb);
            XmlAttrib(sb, "MiniportIfIndex", MiniportIfIndex);
            XmlAttrib(sb, "LowerIfIndex", LowerIfIndex);
            XmlAttrib(sb, "MetadataSize", MetadataSize);
            sb.Append("/>");
            return sb;
        }

        public override string[] PayloadNames
        {
            get
            {
                if (payloadNames == null)
                {
                    payloadNames = new string[] { "MiniportIfIndex", "LowerIfIndex", "MetadataSize" };
                }

                return payloadNames;
            }
        }

        public override object PayloadValue(int index)
        {
            switch (index)
            {
                case 0:
                    return MiniportIfIndex;
                case 1:
                    return LowerIfIndex;
                case 2:
                    return MetadataSize;
                default:
                    Debug.Assert(false, "Bad field index");
                    return null;
            }
        }

        private event Action<PacketMetaDataArgs> m_target;

        protected override internal void SetState(object newState) { m_state = (MicrosoftWindowsNDISPacketCaptureTraceEventParserState)newState; }
        private MicrosoftWindowsNDISPacketCaptureTraceEventParserState m_state;
        #endregion
    }
}
