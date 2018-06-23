using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Utils
{
    class Pinger
    {
        /// <summary>
        /// Execute ping with or without timeout
        /// </summary>
        /// <param name="host">Target host</param>
        /// <param name="timeout">Ping timeout. Enter 0 to disable</param>
        /// <param name="reply">Send string reply reference to function in order to get ping reply</param>
        /// <returns>if valid ping command, and reply</returns>
        public static bool Ping(string host, int timeout, ref string reply)
        {
            reply = "Ping to " + host + " failed, ";
            Ping pinger = new Ping();
            PingReply pingReply;
            try
            {
                if (timeout >  0)
                    pingReply = pinger.Send(host, timeout);
                else
                    pingReply = pinger.Send(host);
            }
            catch (PingException exp)
            {
                reply = exp.Message;
                return false;
            }

            switch (pingReply.Status)
            {
                case IPStatus.Success:
                {
                        reply = "Ping to " + host + " [" + pingReply.Address.ToString() + "] Successful. "
                                 + "RTL: " + pingReply.RoundtripTime.ToString() + " ms";
                        break;
                }
                case IPStatus.BadDestination:
                    {
                        reply += "The ICMP echo request failed because the destination IP address cannot receive " +
                                 "ICMP echo requests or should never appear in the destination address field of " +
                                 "any IP datagram. For example, trying to ping specifying IP address '000.0.0.0' returns this status.";
                        break;
                    }
                case IPStatus.BadHeader:
                    {
                        reply += "Bad Header: The ICMP echo request failed because the header is invalid.";
                        break;
                    }
                case IPStatus.BadOption:
                    {
                        reply += "Bad Option: The ICMP echo request failed because it contains an invalid option.";
                        break;
                    }
                case IPStatus.BadRoute:
                    {
                        reply += "Bad Route: The ICMP echo request failed because there is no valid route " +
                                 "between the source and destination computers.";
                        break;
                    }
                case IPStatus.DestinationHostUnreachable:
                    {
                        reply += "Destination Host Unreachable: The ICMP echo request failed " + 
                                 "because the destination computer is not reachable.";
                        break;
                    }
                case IPStatus.DestinationNetworkUnreachable:
                    {
                        reply += "Destination Network Unreachable: The ICMP echo request failed " +
                            "because the network that contains the destination " +
                            "computer is not reachable.";
                        break;
                    }
                case IPStatus.DestinationPortUnreachable:
                    {
                        reply += "Destination Port Unreachable:  The ICMP echo request failed " +
                            "because the port on the destination computer is not available.";
                        break;
                    }
                    // commneted because only relevant for IPv6
                /*case IPStatus.DestinationProhibited:
                    {
                        reply += "The ICMP echo request failed because the destination IP address cannot receive " +
                                 "ICMP echo requests or should never appear in the destination address field of " +
                                 "any IP datagram. For example, trying to ping specifying IP address '000.0.0.0' returns this status.";
                        break;
                    }*/
                case IPStatus.DestinationProtocolUnreachable:
                    {
                        reply += "Destination Protocol Unreachable: The ICMP echo request failed because the destination computer that is specified " +
                                 "in an ICMP echo message is not reachable, because it does not support the packet's " +
                                 "protocol. This value applies only to IPv4. This value is described in IETF RFC " +
                                 "1812 as Communication Administratively Prohibited.";
                        break;
                    }
                case IPStatus.DestinationScopeMismatch:
                    {
                        reply += "Destination Scope Mismatch: The ICMP echo request failed because the source address and destination address " +
                                "that are specified in an ICMP echo message are not in the same scope. This is " + 
                                "typically caused by a router forwarding a packet using an interface that is outside " + 
                                "the scope of the source address. Address scopes (link-local, site-local, and " + 
                                "global scope) determine where on the network an address is valid.";
                        break;
                    }
                case IPStatus.DestinationUnreachable:
                    {
                        reply += "Destination Unreachable: The ICMP echo request failed because " +
                                "the destination computer that is specified " + 
                                "in an ICMP echo message is not reachable; the " +
                                "exact cause of problem is unknown.";
                        break;
                    }
                case IPStatus.HardwareError:
                    {
                        reply += "Hardware Error: The ICMP echo request failed because of a hardware error.";
                        break;
                    }
                case IPStatus.IcmpError:
                    {
                        reply += "ICMP Error: The ICMP echo request failed because of an ICMP protocol error.";
                        break;
                    }
                case IPStatus.NoResources:
                    {
                        reply += "No Resources: The ICMP echo request failed because of insufficient network resources.";
                        break;
                    }
                case IPStatus.PacketTooBig:
                    {
                        reply += "Packet Too Big: The ICMP echo request failed because the packet containing the request is larger " + 
                                 "than the maximum transmission unit (MTU) of a node (router or gateway) located " +
                                 "between the source and destination. The MTU defines the maximum size of a transmittable packet.";
                        break;
                    }
                case IPStatus.ParameterProblem:
                    {
                        reply += "Paramater Problem: The ICMP echo request failed because a node (router or gateway) encountered problems " +
                                 "while processing the packet header. This is the status if, for example, the header " + 
                                 "contains invalid field data or an unrecognized option.";
                        break;
                    }
                case IPStatus.SourceQuench:
                    {
                        reply += "Source Quench: The ICMP echo request failed because the packet was discarded. This occurs when " +
                                "the source computer's output queue has insufficient storage space, or when packets " + 
                                "arrive at the destination too quickly to be processed.";
                        break;
                    }
                case IPStatus.TimedOut:
                    {
                        reply += "Time Out: The ICMP echo Reply was not received within the allotted time. The default time " +
                                "allowed for replies is 5 seconds. You can change this value " +
                                "using the Overload:System.Net.NetworkInformation.Ping.Send " +
                                "or Overload:System.Net.NetworkInformation.Ping.SendAsync " +
                                "methods that take a timeout parameter.";
                        break;
                    }
                case IPStatus.TimeExceeded:
                    {
                        reply += "Time Exceeded: The ICMP echo request failed because its Time to Live (TTL) value reached zero, " +
                                 "causing the forwarding node (router or gateway) to discard the packet.";
                        break;
                    }
                case IPStatus.TtlExpired:
                    {
                        reply += "TTL Expired: The ICMP echo request failed because its Time to Live (TTL) value reached zero, " + 
                                 "causing the forwarding node (router or gateway) to discard the packet.";
                        break;
                    }
                case IPStatus.TtlReassemblyTimeExceeded:
                    {
                        reply += "TTL Reassembly Time Exceeded: The ICMP echo request " +
                                "failed because the packet was divided into fragments for " +
                                "transmission and all of the fragments were not received within the time allotted " +
                                "for reassembly. RFC 2460 (available at www.ietf.org) specifies 60 seconds as " +
                                "the time limit within which all packet fragments must be received.";
                        break;
                    }
                case IPStatus.Unknown:
                    {
                        reply += "Unknown Reason: The ICMP echo request failed for an unknown reason.";
                        break;
                    }
                case IPStatus.UnrecognizedNextHeader:
                    {
                        reply += "Unrecognized Next Header: The ICMP echo request failed because the Next Header field does not contain a " +
                                 "recognized value. The Next Header field indicates the extension header type (if " +
                                 "present) or the protocol above the IP layer, for example, TCP or UDP.";
                        break;
                    }
            }

            return true;
        }
    }
}
