   M S B A M L   `   `   `  ����  GlobalLabIII'    !GlobalLabIII.VerLibroDiarioWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Libro Diario��5   	   $	��450��6   $	��600��6+   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5	      �  � Color$ #0E2C40��6    � Offset$ 0Q�6/   � 5
      $ #1A4A5A��6   $ 1Q�6/   5      .+�5   
   �� $��Libro Diario��6   $��30(�6'   $
��Bold"�65   $��Georgia)�6G   ���#148D8D$��Center=�6q   $	��Top=�6�   $��0,15,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridLibroDiario��5         
IsReadOnly$
 True��61   $��Stretch=�6C   $��Stretch=�6a   $��20,70q�6}   
���   �$��1q�5   '      AutoGenerateColumns$ False��6;      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #0E2C40��6#   $ 0Q�63   � 5      $ #1A4A5A��6#   $ 1Q�63   5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Movimiento��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
Movimiento+  5      $
 Fecha��6%    64   �� *Fecha+  5       $
 Cuenta��6%    65   �� *Cuenta+  5"      $
 Monto��6%    64   �� *Monto+  5$      $
 
Operación��6%    68   �� *	Operacion+5&      �� 5)   
   -   5        $��Volver��5)      $��
Montserrat)�6"   $
��Bold"�6:   $��Center=�6L   $��Bottom=�6i   $	��100��6�   $��30��6�   $��0,0,0,20q�6�   ��5*      �� 5+       �� 
TargetType" ��6   .�5,      ��  �� Property � �� �� Value �#0E2C4063   �� 5-       � ��
 �����63    �� Triggers 5.      P� 5/       P� Property �@J�IsMouseOver P� Value$
 True��69   . �50      ��  � �� �#0E2C406;   51      53      55      56      57      