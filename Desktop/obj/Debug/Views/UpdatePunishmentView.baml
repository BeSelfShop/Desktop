   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      B >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.ViewsDesktop.Views 5      (   "Desktop.Views.UpdatePunishmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      -localclr-namespace:Desktop.Views     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $��2* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� $��0��6   $��1��6&   $��Center=�66   $��Italic$�6S   $��45(�5      $��	0 0 0 20 q�6#   Edytuj kare5      �� 5   
   $��2��6   $��1��6"    � DataContext 62   �� *GetPunishment+.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Left=�6   $��20(�69   $��
0 0 50 20 q�6G   Data rozpoczęcia5       �� 5!      $	��200��68   $��20��6D   $��	0 0 0 20 q�6P   ��6   �� *	StartDate+6P   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $
��Left=�6   $��20(�69   $��
0 0 50 20 q�6G   Data zakończenia:5'      (  "System.Windows.Controls.DatePicker  5(      -   5          Name$ EndDate��5(      $	��200��6.   $��20��6:   $��0 0 5 20q�6F   
 �� Now   SelectedDate# Z 6X   5)      �� 5+      $ 
Horizontal=�6   .+�5,      �� $
��Left=�6   $��20(�68   $��
0 0 50 20 q�6F   Dożywocie:5.      �� 5/      -   5         ��Name$ Lifery��5/      $	��200��6,   $��20��68   50      �� 52      $ 
Horizontal=�6   .+�53      �� $
��Left=�6   $��20(�68   $��
0 0 50 20 q�6F   	Powód:55      �� 56      -   5         ��Name$ Reasons��56      $	��200��6,   $��20��68   $��	0 0 5 20 q�6D   ��6W   �� *	Reasons+��57      �� 58      .R�59      �� $ 
Horizontal=�6)   .+�5:   "   �� $��	0 0 20 0 q�6H   ��6,   �� *
ReasonName+6H   5;      5<      5>      5?      5@      �� 5C   
   -   5        	 ��Name$	 UpdatePunishment��5C      $��3��6+   $��1��68   $	��100��6H   $��30��6T   .��6a   Edytuj6i   �� 5D   
   -   5        $
	 Back��5D      $��4��6   $��1��6,   $	��100��6<   $��30��6H   $
��Left=�6T   .��6o   	Powrót5E      5H      5I      