   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      B >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.ViewsDesktop.Views 5      %   Desktop.Views.AddPunishmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      -localclr-namespace:Desktop.Views     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6"   $��2��62   $��Center=�6F   $��Italic$�6c   $��45(�5       $��	0 0 0 20 q�6#   
Dodaj kare5"      �� 5$   
   $��1��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Data rozpoczęcia5&      (  "System.Windows.Controls.DatePicker  5'   
   -   5          Name$ 	StartDate��5'      $��1��6(   $��2��65   $	��200��6E   $��20��6Q   $��	0 0 0 20 q�6]   
 �� Now   SelectedDate# Z 5(      �� 5*   
   $��2��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Data zakończenia:5,        5-   
   -   5        $ EndDate��5-      $��2��6&   $��2��63   $	��200��6C   $��20��6O   $��	0 0 5 20 q�6[   # Z 5.      �� 50   
   $��3��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Dożywocie:52      �� 53   
   -   5         ��Name$ Lifery��53      $��3��6#   $��2��60   $	��200��6@   $��20��6L   $��Center=�6X   �� 55   
   $��4��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   	Powód:57      �� 58   
   -   5         ��Name$ Reasons��58      $��4��6$   $��2��61   $	��200��6A   $��20��6M   $��	0 0 5 20 q�6Y   ��6l   �� *	Reasons+ �� SelectedItem 59      �� *SelectedReason+��5:      �� 5;      .R�5<      ��  �� Orientation$ 
Horizontal=�6!   .+�5=      �� ��6$   �� 	 �� Path$	 
ReasonName�5>      5?      5A      �� 5D   
   -   5        
 ��Name$
 AddPunishment��5D      $��9��6(   $��2��65   $	��100��6E   $��30��6Q   .��6^   Dodaj6e   5F      5G      