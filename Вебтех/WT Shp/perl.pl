#!/usr/bin/perl -w
print "Content-type: text/html\n\n";
print "<html><body>\n";
print "ќбъем круглого конуса<br>";
print "S = 1/3*Pi*R^2*H<br>";
print "<form method=\"post\" action=\"\">";
print "R = <input type=\"text\" name=\"R\" value=\"\" /><br>";
print "H = <input type=\"text\" name=\"H\" value=\"\" /><br>";
print "<input type=\"submit\" name=\'calc\' value=\"Calculate\" />";
print "</form>";

 if ($ENV{'REQUEST_METHOD'} eq 'POST')
 {
 use CGI;
 use Math::Trig;
 $my_cgi = new CGI; 
 $R = $my_cgi->param('R'); 
 $H = $my_cgi->param('H'); 
 $S = 1/3*pi*$R*$R*$H;
 if (($R!='')&&($H!='')){
 print "R=",$R," H=",$H," S=",$S;
 }
 else {print "¬ведите данные!";}
 }

 
print "</body></html>";
