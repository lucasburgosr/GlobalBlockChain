   M S B A M L   `   `   `  ����  GlobalLabIII,    &GlobalLabIII.ConsultarLibroMayorWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Consulta Libro Mayor��5   	   $	��300��6&   $	��400��63   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5	      �  � Color$ #401040��6    � Offset$ 0Q�6/   � 5
      $ #A040A0��6   $ 1Q�6/   5      .+�5   
   � $��20q�6   .+�5      �� $��Libro Mayor��6   $��24(�6*   $
��Bold"�68   $��Lucida Calligraphy)�6J   ���#301030$��Center=�6   $	��Top=�6�   $��0,10,0,0q�6�   � 5      $
��0,60q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6   $��Fecha de Inicio:��6)   $��Center=�6A   $��18(�6\   $��Elephant)�6j   ���#3010306�   (  "System.Windows.Controls.DatePicker  5      -   5        $��datePickerInicio��5   ]   $��0��6   $��160, 15, 0, 15q�6*   $��Center=�6B   6]   �� 5      $��1��6   $��Fecha de Fin:��6)   $��Center=�6>   $��18(�6Y   $��Elephant)�6g   ���#3010306}     5       -   5        $��datePickerFin��5    ]   $��1��6   $��160, 15, 0, 15q�6*   $��Center=�6B   6]   5"      �� 5$      -   5        $��	Consultar��5$      $��
Montserrat)�6)   $
��Bold"�6A   $��Stretch=�6S   $	��150��6q   $��30��6}   $��	0,150,0,0q�6�   ��5%      �� 5&       �� 
TargetType" ��6   .�5'      ��  �� Property � �� �� Value �#80408067   �� 5(       � ��
 �����67   	 �� Triggers	 5)      P� 5*      
 P� Property
 �@J�IsMouseOver P� Value$
 True��6=   . �5+   "   ��  � �� �#A040A06?   5,      5.      50      �� 52      -   5        $��Volver��52      $��
Montserrat)�6&   $
��Bold"�6>   $��Right=�6P   $��Bottom=�6l   $��70��6�   $��25��6�   ��53      �� 54      " ��6   .�55      ��  � �� �#80408067   �� 56       � ��
 �����67   	 57      P� 58      
 �@J�IsMouseOver$
 True��6=   . �59   "   ��  � �� �#A040A06?   5:      5<      5>      5?      5@      5A      