#!/usr/bin/perl

read(STDIN,$buffer,$ENV{'CONTENT_LENGTH'});

if($buffer eq "")
{
print <<FORM;
Content-type: text/html\n\n 
<html>
<meta charset="UTF-8">
<body>
<h4>(S1 - площадь верхнего основания, S2 - площадь нижнего основания, h - высота пирамиды)</h4>
<form action="cgi-bin/script.pl" method="POST">
S1:<br>
<input type="text" name="s1">
<br>
S2:<br>
<input type="text" name="s2">
<br>
h:<br>
<input type="text" name="h">
<br><br>
<input type="submit" value="Calc">
</form> 
</body>
</html>
FORM
}
else
{
print "Content-type: text/html\n\n";

print "<html>Answer is:"; 


@pairs = split(/&/,$buffer);
foreach $pair(@pairs)
{
($name, $value) = split(/=/, $pair);
 $name=~s/%([0-9A-Fa-f][0-9A-Fa-f])/chr(hex($1))/ge;
 $value=~s/%([0-9A-Fa-f][0-9A-Fa-f])/chr(hex($1))/ge;
 $name =~ tr/a-z/A-Z/;
 $res{$name} = $value;
}
$a=int($res{"s1"});
$b=int($res{"s2"});
$c=int($res{"h"});
print("V = ",($c*($a+sqrt($a*$b)+$b))/3);
print "</html>";
}