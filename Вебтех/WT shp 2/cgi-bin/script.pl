#!/usr/bin/perl

read(STDIN,$buffer,$ENV{'CONTENT_LENGTH'});


print "Content-type: text/html\n\n";

print "<html>Answer is:"; 


@pairs = split(/&/,$buffer);
foreach $pair(@pairs)
{

($name, $value) = split(/=/, $pair);
$value =~ tr/+/ /;
 $name=~s/%([0-9A-Fa-f][0-9A-Fa-f])/chr(hex($1))/ge;
 $value=~ s/<--(.|\n)*-->//g;
 $res{$name} = $value;
}
$R=int($res{"R"});
$pi=3,14;
print($pi*$R*$R);
print "</html>";
