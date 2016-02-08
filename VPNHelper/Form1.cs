using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPNHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string config = @"日本 4 jp
美国 6 us
新加坡 2 sg
台湾 1 tw
香港 3 hk
英国 1 uk";
            string[] countryList = config.Split('\n');
            foreach (string country in countryList)
            {
                string[] detail = country.Split(' ');
                for (int i = 1; i <= Convert.ToInt32(detail[1]); i++)
                {
                    string title = String.Format(@"{0}{1}", detail[0], i);
                    string server = String.Format(@"{0}{1}", detail[2].Trim(), i);
                    string address = String.Format(@"p1.{0}.vpnbit.com", server);
                    string line = GetTemplate(title, GetGUID(), address);
                    textBox1.Text += line;
                    textBox1.AppendText(Environment.NewLine);
                }
                textBox1.AppendText(Environment.NewLine);
            }

            /*
            string dial1 = GetTemplate("jp1", GetGUID(), "p1.jp1.vpnbit.com");
            
            textBox1.Text += dial1;
            textBox1.AppendText(Environment.NewLine);
            */
        }

        private string GetGUID()
        {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            string str = guid.ToString();
            //textBox1.Text += str;
            //textBox1.AppendText(Environment.NewLine);
            str = str.Replace("-", "");
            //textBox1.Text += str;
            //textBox1.AppendText(Environment.NewLine);
            str = str.ToUpper();
            //textBox1.Text += str;
            //textBox1.AppendText(Environment.NewLine);
            return str;
        }

        private string GetTemplate(string s0, string s1, string s2)
        {
            string template = String.Format(@"[{0}]
Encoding=1
PBVersion=1
Type=2
AutoLogon=0
UseRasCredentials=1
LowDateTime=
HighDateTime=
DialParamsUID=
Guid={1}
VpnStrategy=2
ExcludedProtocols=0
LcpExtensions=1
DataEncryption=256
SwCompression=0
NegotiateMultilinkAlways=0
SkipDoubleDialDialog=0
DialMode=0
OverridePref=15
RedialAttempts=3
RedialSeconds=60
IdleDisconnectSeconds=0
RedialOnLinkFailure=1
CallbackMode=0
CustomDialDll=
CustomDialFunc=
CustomRasDialDll=
ForceSecureCompartment=0
DisableIKENameEkuCheck=0
AuthenticateServer=0
ShareMsFilePrint=1
BindMsNetClient=1
SharedPhoneNumbers=0
GlobalDeviceSettings=0
PrerequisiteEntry=
PrerequisitePbk=
PreferredPort=VPN1-0
PreferredDevice=WAN Miniport (IKEv2)
PreferredBps=0
PreferredHwFlow=0
PreferredProtocol=0
PreferredCompression=0
PreferredSpeaker=0
PreferredMdmProtocol=0
PreviewUserPw=1
PreviewDomain=1
PreviewPhoneNumber=0
ShowDialingProgress=1
ShowMonitorIconInTaskBar=1
CustomAuthKey=0
AuthRestrictions=544
IpPrioritizeRemote=1
IpInterfaceMetric=0
IpHeaderCompression=0
IpAddress=0.0.0.0
IpDnsAddress=0.0.0.0
IpDns2Address=0.0.0.0
IpWinsAddress=0.0.0.0
IpWins2Address=0.0.0.0
IpAssign=1
IpNameAssign=1
IpDnsFlags=0
IpNBTFlags=1
TcpWindowSize=0
UseFlags=2
IpSecFlags=0
IpDnsSuffix=
Ipv6Assign=1
Ipv6Address=::
Ipv6PrefixLength=0
Ipv6PrioritizeRemote=1
Ipv6InterfaceMetric=0
Ipv6NameAssign=1
Ipv6DnsAddress=::
Ipv6Dns2Address=::
Ipv6Prefix=0000000000000000
Ipv6InterfaceId=0000000000000000
DisableClassBasedDefaultRoute=0
DisableMobility=0
NetworkOutageTime=0
ProvisionType=0
PreSharedKey=

NETCOMPONENTS=
ms_msclient=1
ms_server=1

MEDIA=rastapi
Port=VPN1-0
Device=WAN Miniport (IKEv2)

DEVICE=vpn
PhoneNumber={2}
AreaCode=
CountryCode=0
CountryID=0
UseDialingRules=0
Comment=
FriendlyName=
LastSelectedPhone=0
PromoteAlternates=0
TryNextAlternateOnFail=1", s0, s1, s2);
            return template;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string str = String.Format(@"C:\Users\{0}\AppData\Roaming\Microsoft\Network\Connections\Pbk", System.Environment.UserName);
            //textBox1.Text += str;
            textBox1.AppendText(Environment.NewLine);
            System.Diagnostics.Process.Start("Explorer.exe", String.Format(@"C:\Users\{0}\AppData\Roaming\Microsoft\Network\Connections\Pbk", System.Environment.UserName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetDataObject(textBox1.Text.Trim());
                MessageBox.Show("复制成功，你现在可以直接粘贴到任何文本编辑器中了");
            }
            else {
                MessageBox.Show("textBox1文本框中没有内容，无法复制");
            }
        }
    }
}
