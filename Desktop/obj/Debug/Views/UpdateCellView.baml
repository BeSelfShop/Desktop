   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Desktop.ViewsDesktop.Views  5      "    Desktop.Views.UpdateCellView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Desktop.Views     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6"   $��2��62   $��Center=�6F   $��Italic$�6c   $��45(�5      $��	0 0 0 20 q�6#   Edycja Celi5!      �� 5#   
   $��1��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Numer Celi:5%      �� 5&   
   -   5         ��Name$ 
CellNumber��5&      $��1��6&   $��2��63   $	��200��6C   $��20��6O   $��	0 0 0 20 q�6[   �� 5(   
   $��2��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Ilość łóżek:5*      �� 5+   
   -   5        $ 	BedsCount��5+      $��2��6%   $��2��62   $	��200��6B   $��20��6N   $��	0 0 5 20 q�6Z   �� 5-   
   $��8��6   $��1��6"   $
��Left=�62   $��Italic$�6M   $��20(�6`   $��
0 0 50 20 q�6n   Rodzaj celi:5/      �� 50   
   -   5         ��Name$ CellType��50      $��8��6%   $��2��62   $	��200��6B   $��20��6N   $��	0 0 5 20 q�6Z   ��6m   �� *	CellTypes+ �� SelectedItem 51      �� *SelectedCellType+��52      �� 53      .R�54      ��  �� Orientation$ 
Horizontal=�6!   .+�55      �� ��6$   ��  �� Path$ CellName�56      57      59      �� 5;   
   -   5         ��Name$ 
UpdateCell��5;      $��9��6%   $��2��62   $	��100��6B   $��30��6N   .��6[   Edytuj6c   5<      5=      