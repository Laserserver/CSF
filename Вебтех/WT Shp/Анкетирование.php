<html> 
 <head>
 <title>�������������</title>
 <style>
 h1 {
 color: blue
 }
 body{
 background:#BBFFFF;
 }
 </style>
 </head>
 <body>
 <image src="http://www.gks.ru/free_doc/new_site/perepis2010/croc/images/logo.png">
 <h1>�������� ��������� �.��������</h1>
 
 <?   
  $surname=$_GET['surname'];
  $name=$_GET['name'];
  $fname=$_GET['fname'];
  $gender=$_GET['gender'];
  $age=$_GET['age'];
  $email=$_GET['email'];
  $s1=$_GET['s1'];
  $all=$surname.' '.$name.' '.$fname.' '.$gender.' '.$age.' '.$email.' '.$s1\n;
  $file=fopen("text1.txt","a");
  fwrite($file,$all);
  fclose($file);
  ?>
 
 <form action="�������������.php" method=get> 
   ������� �������: <input type=text name=surname><br/> 
   ������� ���: <input type=text name=name><br/>
   ������� ��������: <input type=text name=fname><br/>
   ���:<input name=gender type=radio value="m" checked>�������
   <input name=gender type=radio value="g">�������</br>
   �������:<input type=text name=age><br/>
   E-mail:<input type=text name=email><br/>
   ��������������:<select name="s1">
<option value="rus">�������</option>
<option value="unrus">���������</option>
</select></br>
   <input type=submit value="Ok"> 
  </form> 
 </body>
 </html>