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