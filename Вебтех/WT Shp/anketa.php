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
  $submit=$_GET['submit'];
if(isset($submit))
{  
  $surname=$_GET['surname'];
  $name=$_GET['name'];
  $fname=$_GET['fname'];
  $gender=$_GET['gender'];
  $age=$_GET['age'];
  $email=$_GET['email'];
  $s1=$_GET['s1'];
  if(preg_match("/^[�-�]{1}[�-�]+$/",$surname)==NULL)
  {
  echo "������������ �������";?>   <input type="button" value="�����" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^[�-�]{1}[�-�]+$/",$name)==NULL)
  {
  echo "������������ ���";?>   <input type="button" value="�����" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^[�-�]{1}[�-�]+$/",$fname)==NULL)
  {
  echo "������������ ��������";?>   <input type="button" value="�����" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^\d+$/",$age)==NULL)
  {
  echo "������������ �������";?>   <input type="button" value="�����" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^\S+\@[a-z]+\.ru$/",$email)==NULL)
  {
  echo "������������ E-mail";?>   <input type="button" value="�����" onclick="history.back()"><?
  exit;
  }
  
  
  else
  {
  $all=$surname.' '.$name.' '.$fname.' '.$gender.' '.$age.' '.$email.' '.$s1."\r\n";
  $file=fopen("text1.txt","a");
  fwrite($file,$all);
  fclose($file);
  }
}
  ?>
 
 <form method=get> 
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
   <input type=submit name=submit value="Ok"> 
  </form>   
 </body>
 </html>