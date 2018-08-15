﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PillarBox.Data;
using System;

namespace PillarBox.Data.Migrations
{
    [DbContext(typeof(PillarBoxContext))]
    [Migration("20180316142024_AddingFieldsToMessage")]
    partial class AddingFieldsToMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("PillarBox.Data.Filters.MessageAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionType")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid>("RuleId");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("MessageActions");

                    b.HasDiscriminator<string>("ActionType").HasValue("MessageAction");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageFilter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("FieldName");

                    b.Property<bool>("IsRegularExpression");

                    b.Property<string>("Pattern");

                    b.Property<Guid>("RuleId");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("MessageFilters");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MessageRules");
                });

            modelBuilder.Entity("PillarBox.Data.Messages.Inbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByClientHostname");

                    b.Property<string>("CreatedByClientIP");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<TimeSpan>("MaxAge");

                    b.Property<int>("MaxCount");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentInboxId");

                    b.HasKey("Id");

                    b.HasIndex("ParentInboxId");

                    b.ToTable("Inboxes");
                });

            modelBuilder.Entity("PillarBox.Data.Messages.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bcc");

                    b.Property<string>("Cc");

                    b.Property<string>("CreatedByClientHostname");

                    b.Property<string>("CreatedByClientIP");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateSent");

                    b.Property<string>("From");

                    b.Property<bool>("HasAttachments");

                    b.Property<Guid>("InboxId");

                    b.Property<string>("Source");

                    b.Property<string>("Subject");

                    b.Property<string>("Summary");

                    b.Property<string>("To");

                    b.HasKey("Id");

                    b.HasIndex("InboxId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PillarBox.Data.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PillarBox.Data.Users.UserInbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid>("InboxId");

                    b.Property<bool>("Starred");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InboxId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInboxes");
                });

            modelBuilder.Entity("PillarBox.Data.Users.UserMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<Guid>("MessageId");

                    b.Property<bool>("Starred");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageActionForward", b =>
                {
                    b.HasBaseType("PillarBox.Data.Filters.MessageAction");

                    b.Property<string>("ForwardingAddress");

                    b.ToTable("MessageActionForward");

                    b.HasDiscriminator().HasValue("Foward");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageActionNotification", b =>
                {
                    b.HasBaseType("PillarBox.Data.Filters.MessageAction");

                    b.Property<string>("DeviceToken");

                    b.ToTable("MessageActionNotification");

                    b.HasDiscriminator().HasValue("Notification");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageActionWebHook", b =>
                {
                    b.HasBaseType("PillarBox.Data.Filters.MessageAction");

                    b.Property<string>("PostTemplate");

                    b.Property<string>("TargetUrl");

                    b.ToTable("MessageActionWebHook");

                    b.HasDiscriminator().HasValue("WebHook");
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageAction", b =>
                {
                    b.HasOne("PillarBox.Data.Filters.MessageRule", "Rule")
                        .WithMany("Actions")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PillarBox.Data.Filters.MessageFilter", b =>
                {
                    b.HasOne("PillarBox.Data.Filters.MessageRule", "Rule")
                        .WithMany("Filters")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PillarBox.Data.Messages.Inbox", b =>
                {
                    b.HasOne("PillarBox.Data.Messages.Inbox", "ParentInbox")
                        .WithMany("Children")
                        .HasForeignKey("ParentInboxId");
                });

            modelBuilder.Entity("PillarBox.Data.Messages.Message", b =>
                {
                    b.HasOne("PillarBox.Data.Messages.Inbox", "Inbox")
                        .WithMany("Messages")
                        .HasForeignKey("InboxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PillarBox.Data.Users.UserInbox", b =>
                {
                    b.HasOne("PillarBox.Data.Messages.Inbox", "Inbox")
                        .WithMany()
                        .HasForeignKey("InboxId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PillarBox.Data.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PillarBox.Data.Users.UserMessage", b =>
                {
                    b.HasOne("PillarBox.Data.Messages.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PillarBox.Data.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}