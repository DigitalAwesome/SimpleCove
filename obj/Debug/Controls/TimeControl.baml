   M S B A M L   `   `   `  ����  
SimpleCove%    SimpleCove.Controls.TimeControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  UserControl��5   )   $
��Auto��6   $
��Auto��6   .��5      � -   5         �Name$ 
LayoutRoot��5      $
��Auto��6   $
��Auto��6,    � ColumnDefinitions 5
   
   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   .+�5   
   � -   5        $
 hour��5      |�. .+�5      �� -   5         ��Name$ mmTxt��5      $
��Wrap=�6'    �� TextAlignment$ Center=�5      $��Center=�6)   $��Goudy Stout)�6D   $��14(�6]   ��5   ;   ��  �� Path$ Hours� �� ElementName$ UserControl�� �� Mode$ Default=�5   ]   5      � 5   
   $��1��6   .+�5      �� -   5        $
 sep1��5      $
��Wrap=�6'   $��Center=�6;   $��Goudy Stout)�6l   $��14(�5      $��:��6!   $ Center=�6*   ��5   V   Z� 5   *   5      � 5   
   -   5        $	 min��5       $��2��6   |�. .+�5      �� -   5        $ ddTxt��5      $
��Wrap=�6)   $ Center=�5      $��Center=�6*   $��Goudy Stout)�6E   $��14(�6^   ��5   =   �� $ Minutes�$ UserControl��$ Default=�5   ^   5       � 5#   
   $��3��6   .+�5$      �� -   5        $
 sep2��5$      $
��Wrap=�6'   $��Center=�6;   $��Goudy Stout)�6l   $��14(�5%      $��:��6    $ Center=�6)   ��5$   V   Z� 5%   )   5&      � 5(   
   -	   5        $	��sec��5(       $��4��6   |�. .+�5)      �� -
   5        $ yyTxt��5)      $
��Wrap=�6(   $ Center=�5*      $��Center=�6)   $��Goudy Stout)�6D   $��14(�6]   ��5)   <   �� $ Seconds�$ UserControl��$ Default=�5*   ]   5+      5,      5-      