﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCommentForm.ascx.cs" Inherits="UComment.Usercontrols.AjaxCommentForm" %>
<%@ Import Namespace="UComment.Library" %>

<div id="commentform" class="post-comment">

<div id="gravatar" style="display: none; height: 80px; width:80px;"></div>


    <div class="form-label">
    <label for="author" class="fieldLabel">
       <%= XsltLibrary.Dictionary("#Name", "Your name")%>:
    </label>
    </div>
    <div class="form-input">
    <input type="text" id="author" name="name" class="input-text required" />
    </div>


    <div class="form-label">
    <label for="email" class="fieldLabel">
        <%= XsltLibrary.Dictionary("#Email", "Email address")%> (optional): 
    </label>
    </div>
    <div class="form-input">
    <input type="text" id="email" name="email" class="input-text email" />
    </div>

    <div class="form-label">
    <label for="url" class="fieldLabel">
        <%= XsltLibrary.Dictionary("#Website", "Website url")%> (optional): 
    </label>
    </div>
    <div class="form-input">
    <input type="text" id="url" name="website"  class="input-text url" />
    </div>
    
    <div class="form-label">
    <label for="comment" class="fieldLabel">
       <%= XsltLibrary.Dictionary("#Comment", "Your message")%>:
    </label>
    </div>
    <div class="form-input">
    <textarea id="comment" cols="20" name="comment" rows="7" class="required"></textarea>
    </div>

    <div class="form-submit">
    <input type="submit" id="submitButton" class="submit" value="<%= XsltLibrary.Dictionary("#Submit","Post Comment") %>" />
    </div>
</div>

<div id="commentLoading" style="display: none">
    <%= XsltLibrary.Dictionary("#CommentLoading", "Your comment is being submitted, please wait")%>
</div>

<div id="commentPosted" style="display: none">
    <%= XsltLibrary.Dictionary("#CommentPosted", "Your comment has been posted, thank you very much")%>
</div>

<script type="text/javascript">
    jQuery(document).ready(function(){
          
           
          jQuery("#commentform #email").blur(function(){
                var email = jQuery("#commentform #email").val();
                                
                if(email != ""){
                    var url = "/base/UComment/GetGravatarImage/" + email + "/80.aspx";
                    jQuery.get(url, function(data){
                        if(data != ""){
                             jQuery("#gravatar").css( "background-image","url(" + data + ")" ).show();
                        }else{
                            jQuery("#gravatar").hide();
                        }
                    });
                }
          });
            
          jQuery("form").validate({
          	submitHandler: function(form) {      
			    jQuery("#commentform").hide();
			    jQuery("#commentLoading").show();
			    jQuery("#commentform #submit").attr("enabled", false);
			    
			    var url = "/base/UComment/CreateComment/<umbraco:Item field="pageID" runat="server"/>.aspx";
			    
				jQuery.post(url, { author: jQuery("#commentform #author").val(), email: jQuery("#commentform #email").val() == '' ? 'guest@atomicf1.com' : jQuery("#commentform #email").val(), url: jQuery("#commentform #url").val(), comment: jQuery("#commentform #comment").val() },
                   function(data){
                   
                   jQuery("#commentLoading").hide();
                   jQuery("#commentPosted").show().removeClass("error");
                   
                    if(data == 0){
                          jQuery("#commentPosted").addClass("error").html(" <%= XsltLibrary.Dictionary("#CommentFailed","Your comment could not be posted, we're very sorry for the inconvenience") %> ");
                          jQuery("#commentform").show();
                          jQuery("#commentform #submit").attr("enabled", true);
                    }                     
                   });
			}
			});
    });
</script>