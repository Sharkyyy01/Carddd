   M S B A M L   `   `   `  ����D  @CardIndex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CardIndex.ViewsCardIndex.Views  5   	   '    !CardIndex.Views.AddEmployeeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CardIndex.Views     5   	     � Title$  AddEmployeeWindow��5   	   $	��330��6#   $	��300��60   $	��330��6<   $	��300��6L   $	��330��6[   $	��300��6k   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6!   $��2��61   $+��%Создание сотрудника��6E   $��10q�6`    �� TextAlignment$ Center=�6l   $��16(�6�   �� 5   
   $��1��6   $��0��6!   $��Фамилия��61   $��5q�6@   $ Right=�6K   $��Center=�6a   �� 5   
   $��1��6   $��1��6   $��5q�6I   ��6/   �� *
LastName+6I   �� 5    
   $��2��6   $��0��6!   $��Имя��61   $��5q�6<   $ Right=�6G   $��Center=�6]   �� 5!   
   $��2��6   $��1��6   $��5q�6J   ��6/   �� *	FirstName+6J   �� 5#   
   $��3��6   $��0��6!   $��Отчество��61   $��5q�6A   $ Right=�6L   $��Center=�6b   �� 5$   
   $��3��6   $��1��6   $��5q�6K   ��6/   �� *
MiddleName+6K   �� 5&   
   $��4��6   $��0��6!   $��Дата рождения��61   $��5q�6F   $ Right=�6Q   $��Center=�6g   (  "System.Windows.Controls.DatePicker  5'   
   $��4��6   $��1��6"   $��5q�6U      SelectedDate 62   �� *	BirthDate+6U   �� 5)   
   $��5��6   $��0��6!   $��Должность��61   $��5q�6B   $ Right=�6M   $��Center=�6c   �� 5*   
   $��5��6   $��1��6   $��5q�6I   ��6/   �� *
Position+6I   �� 5,   
   $��6��6   $��0��6!   $ ��Подразделение��61   $��5q�6F   $ Right=�6Q   $��Center=�6g   �� 5-   
   $��6��6   $��1��6   $��5q�6K   ��6/   �� *
Department+6K   �� 5/   
   $��7��6   $��0��6!   $-��'Дата трудоустройства��61   $��5q�6M   $ Right=�6X   $��Center=�6n     50   
   $��7��6   $��1��6"   $��5q�6Z    62   �� *EmploymentDate+6Z   �� 53   
    �� Orientation$ 
Horizontal=�6   $��8��6.   $��0��6;   $��2��6K   $��Right=�6_   $��Center=�6{   .+�54      �� -   5        $��OkButton��54      $��OK��6%   $��5q�62   $��5q�6=   6I   �� 55      -   5        $��CancelButton��55      $��Отмена��6)   $��5q�6:   $��5q�6E   6Q   56      57      58      