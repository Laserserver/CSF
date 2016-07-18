#!D:\My_Files\Dwimperl\perl\bin\perl.exe

$a = <STDIN>;
while(!($a =~ /^\d+$/)){
	print "Try again a\n";
	$a = <STDIN>;
}
print "Now another two.. \n";
$b = <STDIN>;
while(!($b =~ /^\d+$/)){
	print "Try again b\n";
	$b = <STDIN>;
}
print "Good, one more.. \n";
$c = <STDIN>;
while(!($c =~ /^\d+$/)){
	print "Try again c\n";
	$c = <STDIN>;
}
$p = ($a + $b + $c) / 2;
$h = (2 / $a) * (($p * ($p - a) * ($p - $b) * ($p - $c))**0.5);
print "Height-a: ", $h, "\n";
$h = $h * $a / $b;
print "Height-b: ", $h, "\n";
$h = $h * $b / $c;
print "Height-c: ", $h, "\n";