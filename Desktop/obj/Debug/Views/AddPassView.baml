   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      B >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.ViewsDesktop.Views 5         Desktop.Views.AddPassView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      -localclr-namespace:Desktop.Views     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6"   $��2��62   $��Center=�6F   $��Italic$�6c   $��45(�5      $��	0 0 0 20 q�6#   Dodawanie przepustki5      �� 5!   
   $��2��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Data rozpoczęcia:5#      (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ 	StartDate��5$      $��2��6(   $��2��65   $	��200��6E   $��20��6Q   $��	0 0 0 20 q�6]   
 �� Now   SelectedDate# Z 5%      �� 5'   
   $��3��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Data zakończenia:5)        5*   
   -   5        $ EndDate��5*      $��3��6&   $��2��63   $	��200��6C   $��20��6O   $��	0 0 0 20 q�6[   # Z 5+      �� 5-   
   -   5         ��Name$ AddPass��5-      $��4��6"   $��1��6/   $��2��6?   $��Center=�6S   $��20(�6p   .��6�   Dodaj Przepustkę5/      51      52      