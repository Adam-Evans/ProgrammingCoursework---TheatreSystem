   M S B A M L   `   `   `  ����M  ITheatreSystem08220, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TheatreSystem08220.WindowsTheatreSystem08220.Windows  5   	   /    )TheatreSystem08220.Windows.newPerformance   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TheatreSystem08220.Windows     5   	     � Title$  newPerformance��5   	   $	��766��6    $
��1366��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��.2* �6   �� 5      $��* �6   �� 5      $	��.2* �6   �� 5      $��* �6   �� 5      $	��.2* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Create new Performance��6   $��24(�61   $��1��6?   $��4��6O   $
��Bold"�6c   $��Center=�6u   $��Center=�6�   �� 5   
   -   5         ��Name$ titleTextBox��5      $��1��6(   $��1��65   $��Center=�6E   $��40��6`   �� 5   
   $��1��6   $��1��6   $	��Top=�6-   $��10,10,10,10q�6E   $��Title:��6Z   $��Center=�6k   $��20(�6�   �� 5   
   $��1��6   $��3��6   $��Date:��6-   $��Center=�6=   $	��Top=�6Z   $��10,10,10,10q�6r   $��20(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $��1��6)   $��3��66   $��Center=�6F   $��Center=�6c   �� 5   
   $��2��6   $��1��6   $��Description:��6-   $��10,10,10,10q�6D   $��20(�6Y   $	��Top=�6g   $��Center=�6   �� 5   
   -   5        $ descriptionBox��5      $��2��6*   $��1��67   $��Stretch=�6G   $��
0,60,10,60q�6c   $��3��6w   $��3��6�   �� 5    
   -   5         ��Name$ cancelButton��5       $��5��6'   $��4��67   $��Center=�6D   $
��Left=�6_   $	��150��6z   $��40��6�   $��Cancel��6�   6�   �� 5!   
   -   5        $ 
saveButton��5!      $��5��6%   $��4��65   $��Center=�6B   $��Right=�6]   $	��150��6y   $��40��6�   $��10,10,10,10q�6�   $��Save Performance��6�   6�   5"      5#      