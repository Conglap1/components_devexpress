## HQSOFT Design System — Web Guidelines

> **Source:** `Figma Design File — HQSOFT Design System Xspire [Web]` — file key `5wO57mOv5R62xRh618Soly`
>
> **Status:** Color, typography, spacing, icon, and component tokens are shared with the App design system. Platform-specific behavior and layout rules in this document are **Web-only**.
>
> **Đồng bộ Figma (rà soát đầy đủ 2026-04-03):** Tất cả giá trị số (hex, typography, spacing, elevation, variables) trong file này đã được **xác minh trực tiếp từ Figma qua Plugin API & MCP**. Figma vẫn là nguồn chuẩn nếu có cập nhật về sau. Các lỗi trong phiên bản trước đã được sửa: elevation blur sai, radius token không tồn tại, token hover/pressed và surface-2 bị thiếu.

---

## Table of Contents

1. [Color System](#1-color-system)
2. [Typography](#2-typography)
3. [Iconography](#3-iconography)
4. [Spacing & Layout](#4-spacing--layout)
5. [Elevation & Shadows](#5-elevation--shadows)
6. [Components Index](#6-components-index)

---

## 1. Color System

The Web design system uses the **same two-tier token architecture** as the App:

- **Parent Tokens** (`color-{palette}-{step}`) — base palette values, steps 10–100.
- **Theme Tokens** (`color-{role}`) — semantic roles that inherit from Parent Tokens; mapped to CSS variables and vary by Light / Dark theme.

All color values, palettes, and theme mappings are **identical** to the App system to keep brand consistency across platforms. Implementation details below are Web-specific (CSS variables and usage).

---

### 1.1 Parent Token Color Palettes

Scale steps: `10` (lightest) → `100` (darkest).

> **Implementation (Web)**
>
> - Define all parent tokens as CSS variables at the `:root` level (or a base theme wrapper).
> - Naming convention: `--color-{palette}-{step}` (for example: `--color-navy-60`).
> - Do **not** use hex values directly in components; always go through tokens.

#### Black


| Token             | Hex       |
| ----------------- | --------- |
| `color-black-10`  | `#CDCDCE` |
| `color-black-20`  | `#C3C3C5` |
| `color-black-30`  | `#B0B0B2` |
| `color-black-40`  | `#9D9DA0` |
| `color-black-50`  | `#8B8B8E` |
| `color-black-60`  | `#6E6F71` |
| `color-black-70`  | `#48494C` |
| `color-black-80`  | `#2C2D30` |
| `color-black-90`  | `#18191D` |
| `color-black-100` | `#0F1014` |


#### White


| Token             | Hex       |
| ----------------- | --------- |
| `color-white-10`  | `#A6A7A9` |
| `color-white-20`  | `#B0B0B2` |
| `color-white-30`  | `#BABABC` |
| `color-white-40`  | `#C3C3C5` |
| `color-white-50`  | `#CDCDCE` |
| `color-white-60`  | `#D6D6D8` |
| `color-white-70`  | `#DFDFE1` |
| `color-white-80`  | `#E9E9EB` |
| `color-white-90`  | `#F3F3F4` |
| `color-white-100` | `#FCFCFD` |


#### Navy


| Token            | Hex       | Note                       |
| ---------------- | --------- | -------------------------- |
| `color-navy-10`  | `#E8EBF2` |                            |
| `color-navy-20`  | `#D3D7E5` |                            |
| `color-navy-30`  | `#A6AFCA` |                            |
| `color-navy-40`  | `#7A86B0` |                            |
| `color-navy-50`  | `#4D5E95` |                            |
| `color-navy-60`  | `#21367B` | Primary brand (Light mode) |
| `color-navy-70`  | `#1A2B62` |                            |
| `color-navy-80`  | `#14204A` |                            |
| `color-navy-90`  | `#0D1631` |                            |
| `color-navy-100` | `#070B19` |                            |


#### Red


| Token           | Hex       | Note                         |
| --------------- | --------- | ---------------------------- |
| `color-red-10`  | `#FBE9EA` |                              |
| `color-red-20`  | `#F7D3D6` |                              |
| `color-red-30`  | `#F0A7AD` |                              |
| `color-red-40`  | `#E87B84` |                              |
| `color-red-50`  | `#E14F5B` |                              |
| `color-red-60`  | `#D92332` | Secondary brand (Light mode) |
| `color-red-70`  | `#AE1C28` |                              |
| `color-red-80`  | `#82151E` |                              |
| `color-red-90`  | `#570E14` |                              |
| `color-red-100` | `#2B070A` |                              |


#### Green


| Token             | Hex       | Note                      |
| ----------------- | --------- | ------------------------- |
| `color-green-10`  | `#E5F6F3` |                           |
| `color-green-20`  | `#CDEDE7` |                           |
| `color-green-30`  | `#9BDBD0` |                           |
| `color-green-40`  | `#68C8B8` |                           |
| `color-green-50`  | `#36B6A1` |                           |
| `color-green-60`  | `#04A489` | Positive/success semantic |
| `color-green-70`  | `#03836E` |                           |
| `color-green-80`  | `#026252` |                           |
| `color-green-90`  | `#024237` |                           |
| `color-green-100` | `#01211B` |                           |


#### Blue


| Token            | Hex       | Note                 |
| ---------------- | --------- | -------------------- |
| `color-blue-10`  | `#EAEAFF` |                      |
| `color-blue-20`  | `#D5D5FF` |                      |
| `color-blue-30`  | `#ABABFF` |                      |
| `color-blue-40`  | `#8181FE` |                      |
| `color-blue-50`  | `#5757FE` |                      |
| `color-blue-60`  | `#2D2DFE` | Useful/info semantic |
| `color-blue-70`  | `#2424CB` |                      |
| `color-blue-80`  | `#1B1B98` |                      |
| `color-blue-90`  | `#121266` |                      |
| `color-blue-100` | `#090933` |                      |


#### Yellow


| Token              | Hex       | Note                     |
| ------------------ | --------- | ------------------------ |
| `color-yellow-10`  | `#FEF6E5` |                          |
| `color-yellow-20`  | `#FDECCC` |                          |
| `color-yellow-30`  | `#FBDA9A` |                          |
| `color-yellow-40`  | `#F9C767` |                          |
| `color-yellow-50`  | `#F7B535` |                          |
| `color-yellow-60`  | `#F5A202` | Careful/warning semantic |
| `color-yellow-70`  | `#C48202` |                          |
| `color-yellow-80`  | `#936101` |                          |
| `color-yellow-90`  | `#624101` |                          |
| `color-yellow-100` | `#312000` |                          |


#### Orange


| Token              | Hex       |
| ------------------ | --------- |
| `color-orange-10`  | `#FFEEEA` |
| `color-orange-20`  | `#FFDED6` |
| `color-orange-30`  | `#FFBDAC` |
| `color-orange-40`  | `#FF9C83` |
| `color-orange-50`  | `#FF7B59` |
| `color-orange-60`  | `#FF5A30` |
| `color-orange-70`  | `#CC4826` |
| `color-orange-80`  | `#99361D` |
| `color-orange-90`  | `#662413` |
| `color-orange-100` | `#33120A` |


#### Pink


| Token            | Hex       |
| ---------------- | --------- |
| `color-pink-10`  | `#FDE6F1` |
| `color-pink-20`  | `#FBCDE4` |
| `color-pink-30`  | `#F79BC9` |
| `color-pink-40`  | `#F369AE` |
| `color-pink-50`  | `#EF3793` |
| `color-pink-60`  | `#EB0578` |
| `color-pink-70`  | `#BC0460` |
| `color-pink-80`  | `#8D0348` |
| `color-pink-90`  | `#5E0230` |
| `color-pink-100` | `#2F0118` |


#### Purple


| Token              | Hex       |
| ------------------ | --------- |
| `color-purple-10`  | `#EEE5FB` |
| `color-purple-20`  | `#DECCF6` |
| `color-purple-30`  | `#BE99EE` |
| `color-purple-40`  | `#9D66E5` |
| `color-purple-50`  | `#7D33DD` |
| `color-purple-60`  | `#5C00D4` |
| `color-purple-70`  | `#4A00AA` |
| `color-purple-80`  | `#37007F` |
| `color-purple-90`  | `#250055` |
| `color-purple-100` | `#12002A` |


#### Sky


| Token           | Hex       |
| --------------- | --------- |
| `color-sky-10`  | `#E5F6FB` |
| `color-sky-20`  | `#CCECF7` |
| `color-sky-30`  | `#99DAEE` |
| `color-sky-40`  | `#66C7E6` |
| `color-sky-50`  | `#33B5DD` |
| `color-sky-60`  | `#00A2D5` |
| `color-sky-70`  | `#0082AA` |
| `color-sky-80`  | `#006180` |
| `color-sky-90`  | `#004155` |
| `color-sky-100` | `#00202B` |


#### Brown


| Token             | Hex       |
| ----------------- | --------- |
| `color-brown-10`  | `#FCF1E8` |
| `color-brown-20`  | `#F9E4D3` |
| `color-brown-30`  | `#F2C8A6` |
| `color-brown-40`  | `#ECAD7A` |
| `color-brown-50`  | `#E5914D` |
| `color-brown-60`  | `#DF7621` |
| `color-brown-70`  | `#B25E1A` |
| `color-brown-80`  | `#864714` |
| `color-brown-90`  | `#592F0D` |
| `color-brown-100` | `#2D1807` |


---

### 1.2 Gradient Colors


| Token                    | From      | To        |
| ------------------------ | --------- | --------- |
| `black-gradient-1`       | `#0F1014` | `#3E3F43` |
| `white-gradient-1`       | `#F3F3F4` | `#FCFCFD` |
| `navy-gradient-0`        | `#1A2B62` | `#21367B` |
| `navy-gradient-1`        | `#21367B` | `#4D5E95` |
| `navy-gradient-2`        | `#1F2F65` | `#3C4E8B` |
| `red-gradient-0`         | `#AE1C28` | `#D92332` |
| `red-gradient-1`         | `#D92332` | `#E14F5B` |
| `green-gradient-1`       | `#04A489` | `#36B6A1` |
| `blue-gradient-1`        | `#2D2DFE` | `#5757FE` |
| `yellow-gradient-1`      | `#F5A202` | `#F7B535` |
| `orange-gradient-1`      | `#FF5A30` | `#FF7B59` |
| `pink-gradient-1`        | `#EB0578` | `#EF3793` |
| `purple-gradient-1`      | `#5C00D4` | `#7D33DD` |
| `sky-gradient-1`         | `#00A2D5` | `#33B5DD` |
| `brown-gradient-1`       | `#DF7621` | `#E5914D` |
| `brown-light-gradient-1` | `#F07320` | `#F38F4D` |


> **Implementation (Web)**
>
> - Expose gradients either as CSS variables holding the full gradient string (e.g., `--navy-gradient-0: linear-gradient(...)`) or as utility classes (`.bg-navy-gradient-0`).
> - Use gradients sparingly for hero sections, primary CTAs, and dashboards to avoid visual noise.

---

### 1.3 Special Colors


| Token            | Definition                                        |
| ---------------- | ------------------------------------------------- |
| `navy-special-1` | `#21367B` (100%) to `#4D5E95` (0%) — radial/fade |
| `navy-special-2` | `#1A2B62` to `#ABBFFF` to `#21367B` — tri-stop   |
| `navy-special-3` | `#F3F6FF` to `#FCFCFD` — ultra-light tint        |
| `red-special-1`  | `#D92332` (100%) to `#E14F5B` (0%) — radial/fade |
| `red-special-2`  | `#FFF5F5` to `#FDFCFC` — ultra-light tint        |


---

### 1.4 Theme Tokens — Light Mode

> **Implementation (Web)**
>
> - Define theme tokens as CSS variables on a `.theme-light` class (or `html[data-theme="light"]`).
> - Map from `--color-{palette}-{step}` parent tokens; do **not** hard-code hex values directly in components.

#### Brand


| Token                   | Source            | Hex       | Usage                                              |
| ----------------------- | ----------------- | --------- | -------------------------------------------------- |
| `color-primary`         | `color-navy-60`   | `#21367B` | Primary brand — header, primary buttons, key links |
| `color-primary-hover`   | `color-navy-70`   | `#1A2B62` | Hover state on primary interactive elements        |
| `color-primary-pressed` | `color-navy-80`   | `#14204A` | Pressed / active state on primary elements         |
| `color-on-primary`      | `color-white-100` | `#FCFCFD` | Text / icon on primary color                       |
| `color-secondary`       | `color-red-60`    | `#D92332` | Accent / destructive / secondary actions           |
| `color-on-secondary`    | `color-white-100` | `#FCFCFD` | Text / icon on secondary color                     |


#### Background


| Token                   | Source            | Hex       | Usage                       |
| ----------------------- | ----------------- | --------- | ---------------------------- |
| `color-background`      | `color-white-90`  | `#F3F3F4` | Page background             |
| `color-background-1`    | `color-white-100` | `#FCFCFD` | Card / section background   |
| `color-on-background`   | `color-black-100` | `#0F1014` | Primary body text           |
| `color-on-background-1` | `color-black-40`  | `#9D9DA0` | Secondary text              |
| `color-on-background-2` | `color-black-20`  | `#C3C3C5` | Tertiary / placeholder text |


#### Surface


| Token                        | Source            | Hex       | Usage                                     |
| ---------------------------- | ----------------- | --------- | ----------------------------------------- |
| `color-surface`              | `color-white-100` | `#FCFCFD` | Cards, tables, panels                     |
| `color-surface-1`            | `color-white-90`  | `#F3F3F4` | Subtle elevations (filters, summary bars) |
| `color-surface-2`            | `color-white-70`  | `#DFDFE1` | Hover highlight, alternate header bg      |
| `color-reverse-surface`      | `color-black-100` | `#0F1014` | Dark sections (e.g., footer, banners)     |
| `color-surface-disable`      | `color-white-80`  | `#E9E9EB` | Disabled background                       |
| `color-on-surface`           | `color-black-100` | `#0F1014` | Primary text on surface                   |
| `color-on-surface-1`         | `color-black-60`  | `#6E6F71` | Secondary text                            |
| `color-on-surface-2`         | `color-black-40`  | `#9D9DA0` | Tertiary / hint text                      |
| `color-on-surface-3`         | `color-black-20`  | `#C3C3C5` | Disabled text                             |
| `color-on-surface-disabled`  | `color-white-60`  | `#D6D6D8` | Disabled foreground on light surface      |
| `color-on-reverse-surface`   | `color-white-100` | `#FCFCFD` | Text on reverse surface                   |
| `color-on-reverse-surface-1` | `color-white-40`  | `#C3C3C5` | Secondary text on reverse                 |


#### Outline


| Token             | Source           | Hex       | Usage                      |
| ----------------- | ---------------- | --------- | -------------------------- |
| `color-outline`   | `color-white-60` | `#D6D6D8` | Default border, table grid |
| `color-outline-1` | `color-white-80` | `#E9E9EB` | Subtle border              |
| `color-outline-2` | `color-white-90` | `#F3F3F4` | Very subtle separators     |


#### Semantic (same values in both themes)


| Token                | Source            | Hex       | Usage                |
| -------------------- | ----------------- | --------- | -------------------- |
| `color-positive`     | `color-green-60`  | `#04A489` | Success state        |
| `color-stressful`    | `color-red-60`    | `#D92332` | Error / danger state |
| `color-careful`      | `color-yellow-60` | `#F5A202` | Warning state        |
| `color-useful`       | `color-blue-60`   | `#2D2DFE` | Informational state  |
| `color-on-positive`  | `color-white-100` | `#FCFCFD` | Text on success      |
| `color-on-stressful` | `color-white-100` | `#FCFCFD` | Text on error        |
| `color-on-careful`   | `color-white-100` | `#FCFCFD` | Text on warning      |
| `color-on-useful`    | `color-white-100` | `#FCFCFD` | Text on info         |


> **Note:** `color-stressful` = error/danger state trong hệ thống này (tương đương `color-error` trong các design system khác).

---

### 1.5 Theme Tokens — Dark Mode

> **Implementation (Web)**
>
> - Define dark mode theme tokens on `.theme-dark` (or `html[data-theme="dark"]`).
> - Switch between `.theme-light` / `.theme-dark` at the root container; component styles read from the same semantic variables.

#### Brand


| Token                   | Source                          | Hex       | Note                                    |
| ----------------------- | ------------------------------- | --------- | --------------------------------------- |
| `color-primary`         | `color-navy-dark-60`            | `#5073E5` | Lightened for dark background contrast  |
| `color-primary-hover`   | `color-navy-dark-70`            | `#3E5AB2` | Hover state on primary (dark)           |
| `color-primary-pressed` | `color-navy-dark-80`            | `#2A408C` | Pressed / active state on primary (dark)|
| `color-on-primary`      | `color-white-100`               | `#FCFCFD` |                                         |
| `color-secondary`       | `color-red-dark-60`             | `#FF3344` | Lightened for dark background contrast  |
| `color-on-secondary`    | `color-white-100`               | `#FCFCFD` |                                         |


#### Background


| Token                   | Source            | Hex       |
| ----------------------- | ----------------- | --------- |
| `color-background`      | `color-black-100` | `#0F1014` |
| `color-background-1`    | `color-black-90`  | `#18191D` |
| `color-on-background`   | `color-white-100` | `#FCFCFD` |
| `color-on-background-1` | `color-white-40`  | `#C3C3C5` |
| `color-on-background-2` | `color-white-20`  | `#B0B0B2` |


#### Surface


| Token                        | Source            | Hex       |
| ---------------------------- | ----------------- | --------- |
| `color-surface`              | `color-black-90`  | `#18191D` |
| `color-surface-1`            | `color-black-80`  | `#2C2D30` |
| `color-surface-2`            | `color-black-70`  | `#48494C` |
| `color-reverse-surface`      | `color-white-100` | `#FCFCFD` |
| `color-surface-disable`      | `color-black-70`  | `#48494C` |
| `color-on-surface`           | `color-white-100` | `#FCFCFD` |
| `color-on-surface-1`         | `color-white-60`  | `#D6D6D8` |
| `color-on-surface-2`         | `color-white-40`  | `#C3C3C5` |
| `color-on-surface-3`         | `color-white-20`  | `#B0B0B2` |
| `color-on-surface-disabled`  | `color-black-60`  | `#6E6F71` |
| `color-on-reverse-surface`   | `color-black-100` | `#0F1014` |
| `color-on-reverse-surface-1` | `color-black-40`  | `#9D9DA0` |


#### Outline


| Token             | Source           | Hex       |
| ----------------- | ---------------- | --------- |
| `color-outline`   | `color-black-60` | `#6E6F71` |
| `color-outline-1` | `color-black-70` | `#48494C` |
| `color-outline-2` | `color-black-80` | `#2C2D30` |


#### Semantic — same hex values as Light theme

Semantic tokens reuse the same colors; only contrast with surrounding surfaces changes.

---

## 2. Typography

Typography tokens and scales are shared with the App system, but Web has additional **responsive behavior** and **HTML semantics**.

---

### 2.1 Font Family


| Role        | Font               | Fallback                               | Usage             |
| ----------- | ------------------ | -------------------------------------- | ----------------- |
| All UI text | `Roboto`           | `system-ui, -apple-system, sans-serif` | Tất cả text       |
| Icons       | `Font Awesome 6 Pro` | (requires license — self-hosted)     | Icon font glyphs  |


> **Implementation (Web)**
>
> - Load Roboto via self-hosted webfont or a trusted CDN.
> - **Font Awesome 6 Pro là commercial font** — cần license để dùng. Không dùng public CDN; self-host file sau khi có license.
> - Use semantic HTML elements (`h1`–`h6`, `p`, `label`, `button`) mapped to the corresponding token classes.

---

### 2.2 Type Scale

All values extracted directly from Figma text style nodes (verified via Plugin API). Global rule: **letter-spacing = -2% of font-size** (-0.02em) for all Roboto styles.

In Web, use **utility classes** or **CSS custom properties** to map tokens to font-size, line-height, font-weight, and letter-spacing.

#### Display

> Only **weight 700** exists for Display. No 400/500 variants.


| Token                   | Size     | Weight | Line Height | Letter Spacing |
| ----------------------- | -------- | ------ | ----------- | -------------- |
| `roboto/display/lg/700` | `60px`   | 700    | `90px`      | `-1.2px`       |
| `roboto/display/md/700` | `48px`   | 700    | `72px`      | `-0.96px`      |
| `roboto/display/sm/700` | `40px`   | 700    | `60px`      | `-0.8px`       |


#### Heading


| Token                  | Size   | Weights         | Line Height | Letter Spacing |
| ---------------------- | ------ | --------------- | ----------- | -------------- |
| `roboto/heading/lg/`\* | `32px` | 400 / 500 / 700 | `48px`      | `-0.64px`      |
| `roboto/heading/md/`\* | `24px` | 400 / 500 / 700 | `36px`      | `-0.48px`      |
| `roboto/heading/sm/`\* | `20px` | 400 / 500 / 700 | `30px`      | `-0.40px`      |


#### Title


| Token                 | Size   | Weights         | Line Height | Letter Spacing |
| --------------------- | ------ | --------------- | ----------- | -------------- |
| `roboto/title/lg/`\*  | `18px` | 400 / 500 / 700 | `27px`      | `-0.36px`      |
| `roboto/title/md/`\*  | `16px` | 400 / 500 / 700 | `24px`      | `-0.32px`      |
| `roboto/title/sm/`\*  | `14px` | 400 / 500 / 700 | `21px`      | `-0.28px`      |


#### Body


| Token                | Size   | Weights         | Line Height | Letter Spacing |
| -------------------- | ------ | --------------- | ----------- | -------------- |
| `roboto/body/lg/`\*  | `16px` | 400 / 500 / 700 | `24px`      | `-0.32px`      |
| `roboto/body/md/`\*  | `14px` | 400 / 500 / 700 | `21px`      | `-0.28px`      |
| `roboto/body/sm/`\*  | `12px` | 400 / 500 / 700 | `18px`      | `-0.24px`      |


#### Label


| Token                 | Size   | Weights         | Line Height | Letter Spacing |
| --------------------- | ------ | --------------- | ----------- | -------------- |
| `roboto/label/lg/`\*  | `14px` | 400 / 500 / 700 | `21px`      | `-0.28px`      |
| `roboto/label/md/`\*  | `12px` | 400 / 500 / 700 | `18px`      | `-0.24px`      |
| `roboto/label/sm/`\*  | `10px` | 400 / 500 / 700 | `15px`      | `-0.20px`      |


> `\*` = token prefix; append weight to get full name, e.g. `roboto/label/md/500`.
>
> **Note:** `label/sm` = 10px — dưới ngưỡng WCAG khuyến nghị cho body text. Chỉ dùng cho badge count, chip compact, không dùng cho nội dung đọc dài.

---

### 2.3 Weight Reference


| Value | Name    | Used in                                  |
| ----- | ------- | ---------------------------------------- |
| `300` | Light   | Icon font only — decorative icons        |
| `400` | Regular | Body, passive states (Roboto)            |
| `500` | Medium  | Labels, emphasis, nav items (Roboto)     |
| `700` | Bold    | Headings, CTAs, key data (Roboto)        |
| `900` | Solid   | Icon font only — primary / action icons  |


> **Web notes**
> 
> - Use `font-weight: 700` for primary CTAs and key numeric data.
> - Prefer `500` for navigation items and secondary buttons.
> - Icon font: use `900` (Solid) as the default, `300` (Light) for decorative/supporting icons.
> - Avoid using more than **3 type styles** on one view to keep screens clean and scannable.

---

### 2.4 CSS Implementation Reference

```css
/* Base variables */
:root {
  --font-family-base: 'Roboto', system-ui, -apple-system, sans-serif;

  /* Body MD (most common) */
  --text-body-md-size: 14px;
  --text-body-md-lh: 21px;
  --text-body-md-ls: -0.28px;

  /* Heading MD */
  --text-heading-md-size: 24px;
  --text-heading-md-lh: 36px;
  --text-heading-md-ls: -0.48px;
}

/* Utility class pattern */
.text-body-md-400 {
  font-family: var(--font-family-base);
  font-size: var(--text-body-md-size);     /* 14px */
  line-height: var(--text-body-md-lh);     /* 21px */
  font-weight: 400;
  letter-spacing: var(--text-body-md-ls);  /* -0.28px */
}
```

---

## 3. Iconography

The Web system shares the **Font Awesome 6 Pro** icon set with the App but adds guidance for **SVG usage** and **web performance**.

---

### 3.1 Icon Font


| Property | Value                              |
| -------- | ---------------------------------- |
| Library  | Font Awesome 6 Pro                 |
| Weights  | 300 (Light) and 900 (Solid)        |
| Sizes    | 4 standard sizes — see table below |


> **Implementation (Web)**
>
> - Preferred: use **SVG icons** (from the Web Figma file) bundled in your app (icon sprite or individual components).
> - Alternatively, use Font Awesome Pro via your license (self-hosted), not public CDN, to avoid licensing and performance issues.

---

### 3.2 Icon Size Tokens

All sizes are defined as Figma text styles (`icon-font/{size}/{weight}`). Line-height for icons is `AUTO` (no fixed line-height).


| Token              | Size   | Weight      | Letter Spacing | Usage                                       |
| ------------------ | ------ | ----------- | -------------- | ------------------------------------------- |
| `icon-font/xs/300` | `16px` | 300 (Light) | `-0.32px`      | Inline / label-sized, light                 |
| `icon-font/xs/900` | `16px` | 900 (Solid) | `-0.32px`      | Inline / label-sized, bold                  |
| `icon-font/sm/300` | `20px` | 300 (Light) | `-0.40px`      | Compact UI, light                           |
| `icon-font/sm/900` | `20px` | 900 (Solid) | `-0.40px`      | Compact UI, bold                            |
| `icon-font/md/300` | `24px` | 300 (Light) | `-0.48px`      | Standard UI icon, light                     |
| `icon-font/md/900` | `24px` | 900 (Solid) | `-0.48px`      | **Default** — standard UI icon, bold        |
| `icon-font/lg/300` | `32px` | 300 (Light) | `-0.64px`      | Large, light stroke — hero/feature contexts |
| `icon-font/lg/900` | `32px` | 900 (Solid) | `-0.64px`      | Large, bold stroke                          |


---

### 3.3 Usage Rules

- **Default icon**: `icon-font/md/900` (24px, Solid) for most interactive controls.
- Use `weight 300` (Light) for decorative / supporting icons.
- Use `weight 900` (Solid) for primary actions, navigation, and CTAs.
- Active state color: `color-primary` (light: `#21367B`, dark: `#5073E5`).
- Always pair icons with a label for navigation, except in toolbars where the meaning is universally clear.

---

### 3.4 Icon Categories

Based on the latest Foundation screens, the Web icon library currently has these primary groups:


| Category                 | Description                                                                 |
| ------------------------ | --------------------------------------------------------------------------- |
| **Clarifying Icon**      | State/semantic icons — info, warning, error, user, time, finance            |
| **Action Icon**          | Interaction icons — arrows, navigation, edit, share, phone, control actions |
| **Product icons**        | Business domain icons — cart, warehouse, route, barcode, reports            |
| **Featured icons**       | Curated icon bundles (status packs, map markers, file type packs, etc.)     |
| **Alphabet Icon System** | Search/index view by letter and Unicode/codepoint                            |


For the full Unicode mapping and icon list, refer to the **Iconography** page in the Web Figma library (file `5wO57mOv5R62xRh618Soly`).

Alphabet index rows in Foundation are shown in the format:

- `codepoint - icon-name` (for example: `f14a - square-check`, `f002 - search`, `f54e - store`, `f021 - sync`, `f090 - sign-in`, `f08b - sign-out`).
- Grouped by first letter to support quick lookup while designing and implementing.

---

### 3.5 Additional Icon Assets (Foundation)

The latest Foundation export also includes non-font icon assets used by Web flows:

- **Image placeholders** (multiple checkerboard sizes/shapes for loading/empty image states).
- **Flag** assets (country indicator pairs for locale/account contexts).
- **Language** selector assets.
- **Empty** state mini-assets (small illustrations/icons for zero-data states).
- **User avatars** (people portrait sets for profile/staff/customer scenarios).
- **Store / Outlet** photos (retail environment image packs for list/card views).
- **Product illustrations** (packaged goods, apparel, and merchandising assets).
- **Category icons** (small domain/category pictograms for quick filters).
- **Map assets** (map snapshot/background used by map-related modules).

> **Implementation (Web)**
>
> - Treat these as asset components (SVG/PNG), not Font Awesome glyphs.
> - Keep them in a dedicated asset namespace (for example: `assets/foundation/iconography/*`) to avoid mixing with icon-font tokens.
> - Separate vector and raster sources in subfolders (for example: `.../vectors`, `.../images`) for predictable loading and optimization.

---

### 3.6 Logo & Branding (Web)

Logo files and variants are shared with the App, but usage patterns differ on Web.

#### 3.6.1 Logo Usage Areas

- **Site header:** company/product logo on the top-left, linked to the home page.
- **Sign-in / marketing pages:** larger product logo with more whitespace, optionally on gradient or hero imagery.
- **Footer:** small company logo with "Powered by HQSOFT" or legal text.
- **Favicon / app icon:** simplified mark (from Web Figma file), exported as multi-size ICO/PNG.

#### 3.6.2 Web Logo Guidelines

- **Clear space:** Minimum clear space around logo = logo height × 0.25 (25%).
- **Minimum size:**
  - Product logo in header: **24px** height (desktop), **20px** (mobile).
  - Company logo in footer: **20–24px** height.
- **Background contrast:** Ensure sufficient contrast (WCAG AA minimum 3:1 for non-text).
- **Do not:**
  - Distort aspect ratio (always maintain proportions).
  - Rotate, skew, or apply heavy effects.
  - Change logo colors (use provided variants only).
  - Place on busy backgrounds without sufficient contrast.

#### 3.6.3 HTML/CSS Usage Example

```html
<!-- Header -->
<header class="app-header">
  <a href="/" class="logo-link" aria-label="HQSOFT Home">
    <img
      src="/assets/brand/Logo-eSales-SFA/color=brand, size=md.png"
      alt="eSales SFA"
      class="logo logo--header"
    />
  </a>
</header>

<!-- Footer -->
<footer class="app-footer">
  <span class="powered-by">Powered by</span>
  <img
    src="/assets/brand/Logo-HQSOFT/type=horizontal, size=sm.png"
    alt="HQSOFT"
    class="logo logo--footer"
  />
</footer>
```

```css
.logo { display: inline-block; }
.logo--header { height: 32px; }
.logo--footer { height: 24px; margin-left: 8px; }

.app-header {
  display: flex;
  align-items: center;
  height: 64px;
  padding-inline: 24px;
  background: var(--color-primary);
  color: var(--color-on-primary);
}

.app-footer {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 16px 24px;
  background: var(--color-background-1);
  color: var(--color-on-background-1);
  border-top: 1px solid var(--color-outline);
}
```

---

## 4. Spacing & Layout

> **Source:** Figma nodes for `Units`, `Grid`, and Web layouts in file `5wO57mOv5R62xRh618Soly`.

The Web system keeps the same **two-tier token architecture** for spacing and radius:

- **Parent Tokens** — raw multiplier values (`{N}x` → `N × 2 px`). Base unit = **2px**.
- **Theme Tokens** — semantic named tokens (`spacing-{Nx}`, `radius-{Nx}`) that map directly to the same pixel values.

---

### 4.1 Grid System (Web)

The Web layout uses a **responsive grid** with 3 primary breakpoints:


| Grid style     | Columns | Max width | Gutter | Margin |
| -------------- | ------- | --------- | ------ | ------ |
| `grid-mobile`  | 4       | 428px     | 16px   | 16px   |
| `grid-tablet`  | 8       | 834px     | 24px   | 24px   |
| `grid-desktop` | 12      | 1200px    | 24px   | 32px   |


> **Implementation (Web)**
>
> - Use a centered container with `max-width: 1200px` and horizontal padding from tokens (e.g., `spacing-8x` or `spacing-10x`).
> - Use CSS Grid or Flexbox; map the column count to the breakpoint rules above.
> - Keep **one primary column layout** on mobile to reduce cognitive load; reserve multicolumn content for tablet/desktop.

---

### 4.2 Spacing Tokens

**Base unit: 2px** (1x = 2px). Used for padding, margin, gap, and layout primitives.

#### Parent Tokens


| Multiplier | Value (px) |
| ---------- | ---------- |
| `0x`       | `0`        |
| `1x`       | `2`        |
| `2x`       | `4`        |
| `3x`       | `6`        |
| `4x`       | `8`        |
| `5x`       | `10`       |
| `6x`       | `12`       |
| `7x`       | `14`       |
| `8x`       | `16`       |
| `10x`      | `20`       |
| `12x`      | `24`       |
| `16x`      | `32`       |
| `20x`      | `40`       |
| `24x`      | `48`       |
| `28x`      | `56`       |
| `32x`      | `64`       |


#### Theme Tokens


| Token          | Parent Token | Value (px) |
| -------------- | ------------ | ---------- |
| `spacing-none` | `0x`         | `0`        |
| `spacing-1x`   | `1x`         | `2`        |
| `spacing-2x`   | `2x`         | `4`        |
| `spacing-3x`   | `3x`         | `6`        |
| `spacing-4x`   | `4x`         | `8`        |
| `spacing-5x`   | `5x`         | `10`       |
| `spacing-6x`   | `6x`         | `12`       |
| `spacing-7x`   | `7x`         | `14`       |
| `spacing-8x`   | `8x`         | `16`       |
| `spacing-10x`  | `10x`        | `20`       |
| `spacing-12x`  | `12x`        | `24`       |
| `spacing-16x`  | `16x`        | `32`       |
| `spacing-20x`  | `20x`        | `40`       |
| `spacing-24x`  | `24x`        | `48`       |
| `spacing-28x`  | `28x`        | `56`       |
| `spacing-32x`  | `32x`        | `64`       |


> **Web usage guidelines**
>
> - Vertical spacing between stacked sections: `spacing-12x`–`spacing-20x`.
> - Card internal padding: `spacing-6x` (`12px`) or `spacing-8x` (`16px`).
> - Form fields vertical spacing: `spacing-4x`–`spacing-6x`.

---

### 4.3 Border Radius Tokens

**Base unit: 2px** (1x = 2px).

> **Note:** `radius/3x` (6px) và `radius/16x` (32px) **không tồn tại** trong Figma Variables. Đã xoá khỏi bảng này so với phiên bản trước. Max radius token là `14x = 28px`. `radius-pill` không phải Figma token — là giá trị tính toán `height / 2`.

#### Parent Tokens


| Multiplier | Value (px) | Note                          |
| ---------- | ---------- | ----------------------------- |
| `0x`       | `0`        |                               |
| `1x`       | `2`        |                               |
| `2x`       | `4`        |                               |
| `4x`       | `8`        |                               |
| `5x`       | `10`       | Parent only — no Theme alias  |
| `6x`       | `12`       |                               |
| `8x`       | `16`       |                               |
| `10x`      | `20`       |                               |
| `12x`      | `24`       |                               |
| `14x`      | `28`       | Maximum radius token          |


#### Theme Tokens


| Token         | Parent Token | Value (px)   | Notes                          |
| ------------- | ------------ | ------------ | ------------------------------ |
| `radius-none` | `0x`         | `0`          | Sharp corners                  |
| `radius-1x`   | `1x`         | `2`          | Subtle rounding                |
| `radius-2x`   | `2x`         | `4`          | Small elements (chips, badges) |
| `radius-4x`   | `4x`         | `8`          | Inputs, cards (default)        |
| `radius-6x`   | `6x`         | `12`         | Dialogs, panels                |
| `radius-8x`   | `8x`         | `16`         | Large cards                    |
| `radius-10x`  | `10x`        | `20`         | Side panels                    |
| `radius-12x`  | `12x`        | `24`         | Large containers               |
| `radius-14x`  | `14x`        | `28`         | Extra-large containers (max)   |


> `radius-pill` (fully rounded) = `height / 2` — tính toán ở runtime, không phải token Figma.

> **Web usage guidelines**
>
> - Primary buttons: `radius-4x` (8px) theo brand HQSOFT.
> - Cards, tables: `radius-4x`.
> - Dialogs and overlays: `radius-6x` or `radius-8x`.

---

### 4.4 Page Layout


| Zone                        | Value (Desktop)                             |
| --------------------------- | ------------------------------------------- |
| Max content width           | `1200px`                                    |
| Horizontal page padding     | `24px`–`32px` (outer), `16px` inside cards  |
| Top navigation height       | `64px`                                      |
| Secondary toolbar / filters | `48px`–`56px`                               |
| Footer height               | `56px`–`72px`                               |


> **Responsive behavior**
>
> - On tablet and mobile, horizontal padding decreases (`16px` on tablet, `12px`–`16px` on mobile).
> - Navigation may collapse into a hamburger menu on small viewports, following the Figma Web navigation components.
> - Foundation reference frames currently show **mobile artboard 428px** and **desktop artboard 1440px** as baseline preview sizes.

---

## 5. Elevation & Shadows

**Drop shadow (Elevation)** — shadow tokens are shared with the App design system; on Web, implement them with CSS `box-shadow`.

All elevations use shadow color **`#0F0F29`** = `rgb(15, 15, 41)` (system black).

**Value notation:**

| Shorthand          | Meaning                                                                     |
| ------------------ | --------------------------------------------------------------------------- |
| **X**              | Horizontal offset (`offset-x`)                                              |
| **Y**              | Vertical offset (`offset-y`) — positive = shadow below, negative = above   |
| **B**              | Blur radius                                                                 |
| **S**              | Spread radius                                                               |
| **`#0F0F29 (n%)`** | Shadow color with opacity n%                                                |

#### Elevation tokens (verified from Figma Effect Styles)


| Token name           | X  | Y   | B  | S  | Color & Opacity    |
| -------------------- | -- | --- | -- | -- | ------------------ |
| `elevation-bottom-1` | 0  | +2  | 2  | 0  | `#0F0F29` (6%)     |
| `elevation-bottom-2` | 0  | +4  | 10 | -1 | `#0F0F29` (10%)    |
| `elevation-bottom-3` | 0  | +10 | 14 | -4 | `#0F0F29` (12%)    |
| `elevation-top-1`    | 0  | -2  | 2  | 0  | `#0F0F29` (6%)     |
| `elevation-top-2`    | 0  | -4  | 10 | -2 | `#0F0F29` (10%)    |


#### CSS `box-shadow` reference (Web)


| Token                | `box-shadow`                                  |
| -------------------- | --------------------------------------------- |
| `elevation-bottom-1` | `0 2px 2px 0 rgba(15, 15, 41, 0.06)`          |
| `elevation-bottom-2` | `0 4px 10px -1px rgba(15, 15, 41, 0.10)`      |
| `elevation-bottom-3` | `0 10px 14px -4px rgba(15, 15, 41, 0.12)`     |
| `elevation-top-1`    | `0 -2px 2px 0 rgba(15, 15, 41, 0.06)`         |
| `elevation-top-2`    | `0 -4px 10px -2px rgba(15, 15, 41, 0.10)`     |


- **Bottom** tokens cast the shadow downward (typical cards, menus, floating panels).
- **Top** tokens cast the shadow upward (elements visually "lifted" toward the top edge).

Pressed/active states in Figma may use inner shadows; on Web, approximate with a subtle `inset box-shadow` or a background-color change.


| Context                                  | Suggested token                         |
| ---------------------------------------- | --------------------------------------- |
| Cards, list rows, subtle surfaces        | `elevation-bottom-1`                    |
| Dropdowns, popovers, sticky bars         | `elevation-bottom-2`                    |
| Modals, high-emphasis overlays           | `elevation-bottom-3`                    |
| Toolbars / panels with upward separation | `elevation-top-1` or `elevation-top-2` |
| Pressed button / active input            | Inset shadow (no named elevation token) |


---

## 6. Components Index

This section mirrors the structure of the App guidelines but refers to **Web component implementations** in the Figma file `5wO57mOv5R62xRh618Soly`. Component names and categories may be further refined in Figma; always follow the latest Figma page names.

### Actions


| Component                   | Figma Page (Web) |
| --------------------------- | ---------------- |
| Button                      | Button (Web)     |
| Button group / Split button | Button (Web)     |
| Inline action bar           | Action bar (Web) |


### Communication


| Component        | Figma Page (Web)   |
| ---------------- | ------------------ |
| Badge            | Badge (Web)        |
| Snackbar / Toast | Snackbar (Web)     |
| Progress bar     | Progress bar (Web) |
| Alert / Banner   | Alert (Web)        |


### Containment


| Component           | Figma Page (Web)    |
| ------------------- | ------------------- |
| Card                | Card (Web)          |
| Table               | Table (Web)         |
| List and item       | List and item (Web) |
| Dialog / Modal      | Dialog (Web)        |
| Drawer / Side panel | Drawer (Web)        |
| Tabs container      | Tab (Web)           |


### Navigation


| Component          | Figma Page (Web)        |
| ------------------ | ----------------------- |
| Top navigation bar | Navigation bar (Web)    |
| Side navigation    | Navigation drawer (Web) |
| Breadcrumbs        | Navigation (Web)        |
| Pagination         | Pagination (Web)        |
| Stepper            | Stepper (Web)           |


### Input & Selection


| Component          | Figma Page (Web)      |
| ------------------ | --------------------- |
| Text field         | Text field (Web)      |
| Text area          | Text field (Web)      |
| Select / Dropdown  | Menu (Web)            |
| Checkbox           | Checkbox (Web)        |
| Radio button       | Radio button (Web)    |
| Switch / Toggle    | Switch (Web)          |
| Chip / Tag         | Chip (Web)            |
| Date / Time picker | Datetime picker (Web) |
| Calendar           | Calendar (Web)        |
| Slider             | Slider (Web)          |
| Rating             | Rating (Web)          |
| Search field       | Search (Web)          |


### Data Visualization


| Component        | Figma Page (Web) |
| ---------------- | ---------------- |
| Chart components | Chart (Web)      |
| KPI tiles        | Dashboard (Web)  |


---

*Last updated: April 2026 — Đã rà soát và xác minh toàn bộ qua Figma Plugin API + MCP (2026-04-03). Các lỗi đã sửa so với phiên bản trước: elevation blur sai (bottom-1, top-1, top-2), radius token không tồn tại (3x, 16x), token còn thiếu (primary-hover, primary-pressed, surface-2), weight reference thiếu 300/900 icon, label/sm chú thích WCAG. **Figma file `5wO57mOv5R62xRh618Soly` là nguồn chuẩn** nếu có cập nhật về sau.*
