   M S B A M L   `   `   `  ����D  @mp3player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:mp3player	mp3player  5   	       mp3player.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:mp3player     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  
MainWindow��5	   	   $��487.844��6   $��254.492��6-    � 	Resources 5
         Play �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%C  &	        �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 100��6!   #��z��64   $��1q�6^   ._�5      �� $��Center=�6/   $��Center=�6L   6i   5      5      5      5      5      .��5      �  J� RenderTransformOrigin$ 0.671,0.538&�6   .+�5   
   �� -   5         ��Name$ button��5      $
��Left=�6"   $��
88,150,0,0q�6=   $	��Top=�6Q   $��68��6i   $��68��6u   ��6�   �� *play+��6�   �� *	Selecteds+��5      �� 5      " ��6"   .R�5      � .+�5      A� 
���   �6"   �� 5       $��Center=�6+   $��Center=�6H   � 5!      $��45��6   $��40��6+   .+�5"      � 
�������	 � Points'	 �   @KL @KL @KL  Zb Zb -1y�6L   �� 
 �� Path$
 	Isplaying� �� 	Converter )   #mp3player.BoolToVisibilityConverter    System.Windows.Visibility   Hidden �� ConverterParameter# Z � 5#      
�������)	 �   @KL  Zb �  Zb � @KL y�6Q   �� $
 	Isplaying�      Visible# Z � 5$      
�������1	 �    ?�@KL  ?� Zb Zb Zb Zb@KL y�6R   �� $
 	Isplaying�   # Z �� 5%      $��Center=�6/   $��Center=�6L   5&      5'      5(      5+      �� 5,   
   -   5        $ button1��5,      $
��Left=�6#   $��
10,169,0,0q�6>   $	��Top=�6R   $��64��6j   ��6u   �� *back+��5-      �� 5.      " ��6"   .R�5/      � $��35��6   $��60��6'   .+�50      � #	 �   ` -1@KL  -1���
���   �$ 0.442,0.922&�6J   �� 51      $��Center=�6+   $��Center=�6F   � 52      '	 �   ���`���@KL ������
���   �$ 0.442,0.922&�6K   �� 53      $��Center=�6+   $��Center=�6F   54      55      57      �� 58   
   -   5        $ button2��58      $
��Left=�6#   $��172,169,0,0q�6>   $	��Top=�6S   $��50��6k   ��6v   �� *	further+��5:      �� 5;      " ��6"   .R�5<      � $��35��6   $��60��6'   .+�5=      � 	 �    -1`@KL ���
���   �$ 0.442,0.922&�6I   �� 5>      $��Center=�6+   $��Center=�6F   � 5?      '	 �   ���`���@KL ������
���   �$ 0.442,0.922&�6K   �� 5@      $��Center=�6+   $��Center=�6F   5A      5B      5E      �� 5F   
   -   5        $ button3��5F      $
��Load��6"   $
��Left=�61   $��
10,368,0,0q�6L   $	��Top=�6`   $��75��6x   ��6�   �� *open+&   System.Windows.Controls.DataGrid  5G   
   -   5          Name$ listBox��5G      $
��Left=�6w   $	��110��6�   $��
10,242,0,0q�6�   $	��Top=�6�   $	��212��6�      AutoGenerateColumns .     CanUserAddRows .  ��6%   �� $
 Songs� �� SelectedItem 6H   �� *	Selecteds+ �� Mode$ TwoWay=�   Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ Songs��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *NameS+6N   5M      �� 5N   
   -   5        $ button4��5N      $��Remove��6"   $
��Left=�63   $��139,368,0,0q�6N   $	��Top=�6c   $��83��6{   ��6�   �� *remove+��6�   �� *	Selecteds+�� 5O   
   -   5         ��Name$ slider��5O      $
��Left=�6!   $��
10,101,0,0q�6<   $	��Top=�6P   $	��212��6h    � Minimum$ 0Q�6�    � Maximum$ 1Q�6�    �� IsMoveToPointEnabled .  � Value 6t   �� *SliderValue+$ TwoWay=�6  �� 5P   
   -   5        $ button5��5P      $��Shuffle��6"   $
��Left=�64   $��
10,416,0,0q�6O   $	��Top=�6c   $��75��6{   $ 
0.04,0.591&�6�   ��6�   �� *	shuffle+�� 5Q   
   -	   5        $ button6��5Q      $��Repeat��6"   $
��Left=�63   $��139,416,0,0q�6N   $	��Top=�6c   $��83��6{   ��6�   �� *repeat+�� 5R   
   -
   5         ��Name$ label��5R      $
��Left=�6<   $��	7,123,0,0q�6W   $	��Top=�6j   ��6   �� *
Position+6j   �� 5S   
   -   5        $ label1��5S      $
��Left=�6>   $��181,123,0,0q�6Y   $	��Top=�6n   ��6    �� *	TotalTime+6n   �� 5T   
   -   5         ��Name$ image��5T      $
��Left=�6   $��96��6:   $��69,5,0,0q�6F   $	��Top=�6X   $	��153��6p   "  WpfAnimatedGif.ImageBehavior   RepeatBehavior$ Forever��6|       AnimatedSource$  Images/liz.gif��6�   5X      5Y      