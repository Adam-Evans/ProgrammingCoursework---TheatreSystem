   M S B A M L   `   `   `  ����M  ITheatreSystem08220, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TheatreSystem08220TheatreSystem08220  5   	       TheatreSystem08220.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TheatreSystem08220     5   	   -   5        $��loginWindow��5   0     � Title$  Login��6	   $	��250��6   $	��450��6$   .��5	      � $��20,21q�6    � ColumnDefinitions 5
   
   �� 5      $��0.25* �6   6/   �� 5      $��2* �6   6,   �� 5      $��0.75* �6   6/    � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $��* �6   6)   .+�5   
   G� -   5         G�Name$ passwordBox��5      $��Center=�6+   $��Center=�6H   $	��250��6c   $��25��6o   $��1��6{   $��2��6�    � ToolTip$ Enter Password here��6�   $��1��6�   �� 5   
   -   5         ��Name$ UsernametextBox��5      $	��250��6+   $��25��67   $��1��6C   $��Center=�6S   $��1��6p    �� TextWrapping$
 Wrap=�6}   $��UserName��6�   $��Center=�6�   $��0��6�   6�   �� 5   
   -   5         ��Name$ button��5      $��Login��6!   $��2��61   $��Center=�6A   $��2��6_   $��Center=�6l   $��75��6�   -  'System.Windows.Input.KeyboardNavigation   TabIndex$ 2��6�   	 �� 	IsDefault	 . 6�   �� 5   
   -   5        
 ��Name$
 label��5      $.��(Please enter your username and password.��6   $��1��6R   $��Center=�6b   $��3��6   $��Center=�6�   5      5      