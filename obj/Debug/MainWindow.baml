   M S B A M L   `   `   `  ����L  HProjectFoundation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectFoundationProjectFoundation  5   	   "    ProjectFoundation.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.2.0.2581, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:ProjectFoundation  5   	     � Title$  
MainWindow��5	   	   $	��800��6   $
��1280��6)    � WindowState$ Normal=�66    � WindowStyle$
 None=�6K    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6x   
������ '  !System.Windows.Shell.WindowChrome   WindowChrome 5
        5   
      CaptionHeight$ 30Q�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 	10 0 0 10��6!   ��5      �� 5      	 �� 
StartPoint$		 1,0&�6&   
 �� EndPoint$	
 0,1&�67   .��5      �  � Color$ #d7dee4��6#    � Offset$ 0Q�63   � 5      $ #d7dee4��6#   $ 1Q�63   5      ._�5      � $	��300��6   
������ .+�5      �� $��0 30 0 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��APPLICATION��6$   
���   �$��25(�6J   $��DemiBold"�6X   $��	30 0 50 0q�6n   �� 5      -   5         ��Name$ BackwardBtn��5   !   $��0q�66   
������ $��0q�6c   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�66   
���   �$��20��6\   $��20��6h   $��Center=�6s   $��0 0 10 0q�6�   5      �� 5       -   5        $ 
ForwardBtn��5    !   $��0q�65   
������ $��0q�6b   .��5!        $ ChevronRight=�66   
���   �$��20��6]   $��20��6i   $��Center=�6t   5"      5#      5$      �� 5%      -   5         ��Name$ NavBar��5%   /   $��0 30 0 0q�6   .+�5&      �� $��30 100 0 10q�6    $��EXPLORE��65   
���   �$��17(�6W   $��DemiBold"�6e   �� 5'      -   5        $ 
ExploreNav��5'   T   $ 
Horizontal=�6!   $��45��6:    J� Opacity$	 0.8Q�6F   ��5(      �� 5)       �� Opacity$	 0.3Q�6.    �� Color$ White��6<   .+�5+      ��    	Gradient1#��[  6$   $��5��6F     5,      #��[  62   $ Explore=�6Z   $��25��6i   $��25��6u   $��Center=�6�   $��25 0 0 0q�6�   �� 5-      $��Explore��6$   
���   �$��Center=�6F   $��10 0 0 0q�6a   $��13(�6s   5.      �� 5/      $ 
Horizontal=�6!   $��40��6:   $	 0.8Q�6F   ��50      �� 51      $ 0Q�6.   $ White��6:   .+�53      �� $y�Hidden=�6$   #��[  68   $��5��6Z     54      $ ThumbsUp=�62   
���   �$��25��6U   $��25��6a   $��Center=�6l   $��25 0 0 0q�6�   �� 55      $��Recommended��6$   
���   �$��Center=�6J   $��10 0 0 0q�6e   $��13(�6w   56      �� 57      $��
30 30 0 10q�6    $��Local��64   
���   �$��17(�6T   $��DemiBold"�6b   �� 58      -   5        $ 
LibraryNav��58   T   $ 
Horizontal=�6!   $��40��6:   $	 0.8Q�6F   ��59      �� 5:      $ 0Q�6.   $ White��6:   .+�5<      �� $y�Hidden=�6$   #��[  68   $��5��6Z     5=      $ LibraryMovie=�62   
���   �$��25��6Y   $��25��6e   $��Center=�6p   $��25 0 0 0q�6�   �� 5>      $��Library��6$   
���   �$��Center=�6F   $��10 0 0 0q�6a   $��13(�6s   5?      �� 5@      -   5        $ DownloadsNav��5@   T   $ 
Horizontal=�6!   $��40��6:   $	 0.8Q�6F   ��5A      �� 5B      $ 0Q�6.   $ White��6:   .+�5D      �� $y�Hidden=�6$   #��[  68   $��5��6Z     5E      $ 	Downloads=�62   
���   �$��25��6V   $��25��6b   $��Center=�6m   $��25 0 0 0q�6�   �� 5F      $��	Downloads��6$   
���   �$��Center=�6H   $��10 0 0 0q�6c   $��13(�6u   5G      �� 5H      $ 
Horizontal=�6!   $��40��6:   $	 0.8Q�6F   ��5I      �� 5J      $ 0Q�6.   $ White��6:   .+�5L      �� $y�Hidden=�6$   #��[  68   $��5��6Z     5M      $ Queue=�62   
���   �$��25��6R   $��25��6^   $��Center=�6i   $��25 0 0 0q�6�   �� 5N      $��Personal List��6$   
���   �$��Center=�6L   $��10 0 0 0q�6g   $��13(�6y   5O      5P      5Q      5R      �� 5S   
   $��1��6   ���#f8f8f8$ 	0 10 10 0��66    J� Effect 5T      3  -System.Windows.Media.Effects.DropShadowEffect  5U         
BlurRadius$ 30Q�6#      Opacity$	 0.1Q�63      	Direction$	 -99Q�6A      ShadowDepth$ 4Q�6Q   ._�5W      �  � RowDefinitions 5X      �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   �� 5[      $��* �6$   .+�5]      � $��0��6   $��40��6$   � 5^      $��1��6   $��30��6$   $��50 0 0 0q�60    5_      �� 5`      $
��auto �6+   �� 5a      $
��auto �6+   �� 5b      $��* �6+   .+�5d      �� $��0��6   .��5e        $ ChevronLeft=�62   5f      �� 5g      $��1��6   $��10 0 0 0q�6-   .��5h        $ ChevronRight=�62   5i      5j      �� 5k      -   5         ��Name$ 
ViewHolder��5k   &   $��2��6   5m      5n      5o      5p      5q      