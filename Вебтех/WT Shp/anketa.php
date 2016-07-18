<html> 
 <head>
 <title>Анкетирование</title>
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
 <h1>Перепись населения г.Воронежа</h1>
 
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
  if(preg_match("/^[А-Я]{1}[а-я]+$/",$surname)==NULL)
  {
  echo "Неправильная фамилия";?>   <input type="button" value="Назад" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^[А-Я]{1}[а-я]+$/",$name)==NULL)
  {
  echo "Неправильное имя";?>   <input type="button" value="Назад" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^[А-Я]{1}[а-я]+$/",$fname)==NULL)
  {
  echo "Неправильное отчество";?>   <input type="button" value="Назад" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^\d+$/",$age)==NULL)
  {
  echo "Неправильный возраст";?>   <input type="button" value="Назад" onclick="history.back()"><?
  exit;
  }
  if(preg_match("/^\S+\@[a-z]+\.ru$/",$email)==NULL)
  {
  echo "Неправильный E-mail";?>   <input type="button" value="Назад" onclick="history.back()"><?
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
   Введите фамилию: <input type=text name=surname><br/> 
   Введите имя: <input type=text name=name><br/>
   Введите отчество: <input type=text name=fname><br/>
   Пол:<input name=gender type=radio value="m" checked>Мужской
   <input name=gender type=radio value="g">Женский</br>
   Возраст:<input type=text name=age><br/>
   E-mail:<input type=text name=email><br/>
   Национальность:<select name="s1">
<option value="rus">Русский</option>
<option value="unrus">Нерусский</option>
</select></br>
   <input type=submit name=submit value="Ok"> 
  </form>   
 </body>
 </html>