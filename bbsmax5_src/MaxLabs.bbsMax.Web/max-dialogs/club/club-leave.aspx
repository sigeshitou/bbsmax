﻿<!--[DialogMaster title="退出群组" width="400"]-->
<!--[place id="body"]-->
<form action="$_form.action" method="post">
<!--[if $DisplayMessage]-->
   <div class="clearfix dialogbody">
    <div class="dialogform dialogform-horizontal">
          <div class="dialogconfirm">
                    <h3>您已成功的退出群组</h3>
          </div>
    </div>
</div>

<div class="clearfix dialogfoot">
    <button class="button" name="join"  accesskey="y" title="确定" onclick="panel.close();"><span>确定(<u>Y</u>)</span></button>
</div>
   <!--[else]-->
   <!--[include src="_error_.ascx" /]-->
<div class="clearfix dialogbody">
    <div class="dialogform dialogform-horizontal">
          <div class="dialogconfirm">
                    <h3>你确定要退出此群组吗？</h3>
          </div>
    </div>
</div>

<div class="clearfix dialogfoot">
    <input type="hidden" name="id" value="$_get.id" />
    <button class="button button-highlight" type="submit" name="leave" accesskey="y" title="确定"><span>确定(<u>Y</u>)</span></button>
    <button class="button" type="reset" accesskey="c" title="取消" onclick="panel.close();"><span>取消(<u>C</u>)</span></button>
</div>
    <!--[/if]-->
</form>
<!--[/place]-->
<!--[/dialogmaster]-->