   M S B A M L   `   `   `  ����  GlobalLabIII,    &GlobalLabIII.ConsultarLibroMayorWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  Consulta Libro Mayor��5      $	��300��6%   $	��400��62   .��5      � ��5   	   �� 5       �� 
StartPoint$	 0,0&�6!    �� EndPoint$	 1,1&�62   .��5	      �  � Color$ #0E2C40��6    � Offset$ 0Q�6.   � 5
      $ #1A4A5A��6   $ 1Q�6.   5      .+�5   	   � $��20q�6   .+�5      �� $��Libro Mayor��6   $��24(�6)   $
��Bold"�67   $��Georgia)�6I   ���#148D8D$��Center=�5      $	��Top=�60   $��0,10,0,0q�6H   � 5      $
��0,60q�6    � RowDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��Fecha de Inicio:��6(   $��Center=�6@   $��18(�6[   $��Elephant)�5      
�������61   (  "System.Windows.Controls.DatePicker  5       -   5        $��datePickerInicio��5!      $��0��5       $��160, 15, 0, 15q�6)   $��Center=�6A   5!   4   �� 5$      $��1��6   $��Fecha de Fin:��6(   $��Center=�6=   $��18(�6X   $��Elephant)�5%      
�������61     5&      -   5        $��datePickerFin��5'      $��1��5&      $��160, 15, 0, 15q�6)   $��Center=�6A   5(      5*      �� 5,      -   5        $��	Consultar��5,      $��
Montserrat)�6(   $
��Bold"�6@   $��Stretch=�6R   $	��150��5-      $��30��6    $��	0,150,0,0q�6,   ��5.      �� 5/       �� 
TargetType" ��6   .�50      ��  �� Property � �� �� Value �#0E2C4066   �� 51       � ��
 �����66   	 �� Triggers	 52      P� 53      
 P� Property
 �@J�IsMouseOver P� Value$
 True��6<   . �54   !   ��  � �� �#A040A06>   55      57      59      �� 5<      -   5        $��Volver��5<      $��
Montserrat)�6%   $
��Bold"�6=   $��Right=�6O   $��Bottom=�5=      $��70��6/   $��25��6:   ��5>      �� 5?      " ��6   .�5@      ��  � �� �#0E2C4066   �� 5A       � ��
 �����66   	 5B      P� 5C      
 �@J�IsMouseOver$
 True��6<   . �5D   !   ��  � �� �#A040A06>   5E      5G      5I      5J   
   5K      5L      