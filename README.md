# LogViewer

Microsoft Visual Studio 2020

.net 6

## TOC

* [Code Checkout](#CodeCheckout)
* [Azure EC2 website](#AWSsite)
* [Overview](#Overview)
* [Misc. Notes](#MiscNotes)


## <a name="CodeCheckout">Code Checkout</a>

<code>
git clone https://github.com/xCKtmdl/LogViewer.git
<code>

## <a name="AWSsite">AWS EC2 website</a>

<a href="http://3.129.244.201" target="_blank" rel="noopener">http://3.129.244.201</a>

## <a name="Overview">Overview</a>

I made the constraint to only accept plain text .txt files. You will find in
\
the root directory of the repo the file original.txt which is the sample data
\
you provided me.

Drag and drop the .txt of cef network data you want to use here in the
\
grey area.

![drag-drop](/doc/images/drag-drop.jpg)


If there is no problem with the file, you will see your data loaded here
\
in the Dashboard page.

![drag-drop](/doc/images/dashboard.jpg)


At the top middle of the page you will find a color legend.

![drag-drop](/doc/images/legend.jpg)


Since this is a simple Bootstrap table, you will find all of the columns
\
click-sortable, and there is a search box by which you can filter out
\
various entries.


![drag-drop](/doc/images/bootstrap-table.jpg)


## <a name="MiscNotes">Misc. Notes</a>


I do not have the knowledge of a pentester, network engineer, or malware
\
analyst. Although I know where to find all these kind of resources and quickly
\
assimilate and ingratiate myself to the community.


That being said, much of this data is mysterious to me, and I therefore made
\
up some arbitrary assumptions and rules as to what to count as cautions, alerts,
\
and what information to display.


I found someone's page that had some notes on their Adlumin coding assessment


<a href="https://dariocarlino908.medium.com/parser-coding-assesment-slash-project-4a0b559a50d8">Parser Coding Assesment</a>


In this person's code they seem to use cs1=WCU-External-Inbound and 
\
dhost=DTM-AdluminMBP as Private IP rules. Although I decided to use more
\
naive methods in my code to calculate the validity of an ip address or
\
whether or not it is private, I still decided to highlight these features
\
as you can see the blue color I use for recognized Adlumin traffic.


By the rule I use for calculating if an IP address is valid or not, I was
\
ommitting a very curious entry.


<code>
<37>CEF:0|TippingPoint|UnityOne|1.0.0.17|7611|RepDV-Malware-Severe|1|app=IP cnt=1  dst=216.69.185.6 dpt=443 act=Block cn1=219 cn1Label=VLAN ID cn2=33554431 cn2Label=Taxonomy  cn3=0 cn3Label=Packet Trace cs1=WCU-Internal cs1Label=Profile Name  cs2=6cc0731b-914d-4f78-bf97-0740ef196c53 cs2Label=Policy UUID  cs3=00000001-0001-0001-0001-000000007611 cs3Label=Signature UUID cs4=2-3B 2-3A  cs4Label=ZoneNames cs5=TipSMS cs5Label=SMS Name dvchost=PAS-TP2600NX-02  cs6=cdn.advancedmactools.com cs6Label=Filter Message Parms src=257.26.100.19 spt=30974  externalId=19277755 rt=1539338744077 cat=Reputation proto=IP deviceInboundInterface=19  c6a2= c6a2Label=Source IPv6 c6a3= c6a3Label=Destination IPv6 request= requestMethod=  dhost= sourceTranslatedAddress=257.26.100.19 c6a1= c6a1Label=Client IPv6 suser= sntdom=  duser= dntdom
</code>

\
This ip seemed invalid to me 257.26.100.19. But then I noticed the
\
"RepDV-Malware-Severe" part. I then decided it isn't for me to decide what
\
entries have valid IPs or not, as this data clearly comes from some other tool
\
and that I merely want to highlight features. I therefore decided to keep such
\
entries and use the same yellow caution tag for marking Public IPs to highlight
\
what I consider invalid IPs.


As this seemed like an important entry to keep and display for a user, I added
\
the alert rule that valid CEF lines containing the words "malware" or "severe"
\
add to that entries Alert level.